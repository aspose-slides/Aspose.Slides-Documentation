---
title: Tối ưu hóa quản lý hình ảnh trong bản trình chiếu sử dụng C++
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/cpp/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thêm bitmap
- thay thế hình ảnh
- thay thế ảnh
- từ web
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- tài nguyên SVG bên ngoài
- bộ giải quyết SVG
- hình ảnh SVG được liên kết
- phông chữ SVG
- thêm EMF
- thêm WMF
- thêm TIFF
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tinh giản quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho C++, tối ưu hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bản trình chiếu trở nên hấp dẫn hơn và bắt mắt hơn. Trong Microsoft PowerPoint, bạn có thể chèn hình ảnh vào các slide từ tệp, internet hoặc các nguồn khác. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trình chiếu theo nhiều cách. 

{{% alert title="Mẹo" color="primary" %}} 

Aspose cung cấp các bộ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp bạn nhanh chóng tạo bản trình chiếu từ ảnh. 

{{% /alert %}} 

{{% alert title="Thông tin" color="info" %}}

Nếu bạn muốn thêm hình ảnh dưới dạng khung ảnh—đặc biệt nếu dự định thay đổi kích thước, áp dụng hiệu ứng hoặc sử dụng các tùy chọn định dạng tiêu chuẩn khác—xem [Khung ảnh](/slides/vi/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Ghi chú" color="warning" %}}

Bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Xem các trang sau: chuyển đổi [ảnh sang JPG](https://products.aspose.com/slides/vi/cpp/conversion/image-to-jpg/), [JPG sang ảnh](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-image/), [JPG sang PNG](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-png/), [PNG sang JPG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-jpg/), [PNG sang SVG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-svg/), và [SVG sang PNG](https://products.aspose.com/slides/vi/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides hỗ trợ các định dạng ảnh phổ biến như JPEG, PNG, BMP, GIF và các định dạng khác. 

## **Thêm hình ảnh lưu trữ cục bộ vào slide**

Bạn có thể thêm một hoặc nhiều hình ảnh được lưu trên máy tính của mình vào một slide trình chiếu. Đoạn mã mẫu C++ sau cho thấy cách thêm hình ảnh vào slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Thêm hình ảnh từ web vào slide**

Nếu hình ảnh bạn muốn thêm vào slide không được lưu trên máy tính, bạn có thể thêm nó trực tiếp từ web. 

Đoạn mã mẫu C++ sau cho thấy cách thêm hình ảnh từ web vào slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Thêm hình ảnh vào Slide Master**

Slide master lưu trữ và kiểm soát thông tin như giao diện và bố cục cho các slide sử dụng nó. Khi bạn thêm hình ảnh vào slide master, hình ảnh sẽ xuất hiện trên mọi slide dựa trên master đó. 

Đoạn mã mẫu C++ sau cho thấy cách thêm hình ảnh vào slide master:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Thêm hình ảnh làm nền slide**

Bạn có thể sử dụng một hình ảnh làm nền cho một hoặc nhiều slide. Để biết chi tiết, xem *[Cài đặt hình ảnh làm nền cho slide](/slides/vi/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG vào bản trình chiếu**

Nội dung SVG có thể được thêm vào bản trình chiếu bằng lớp [SvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/svgimage/). Đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) thu được sau đó có thể được thêm vào bộ sưu tập ảnh của bản trình chiếu và dùng để tạo khung ảnh. 

Ví dụ C++ sau nhập một chuỗi SVG độc lập. Tất cả hình ảnh, kiểu dáng và các tài nguyên khác được SVG sử dụng đều được nhúng trực tiếp trong nội dung SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nhập nội dung SVG có tài nguyên bên ngoài**

Các tệp SVG được xuất từ công cụ thiết kế, trình chỉnh sửa sơ đồ, hệ thống biểu tượng và quy trình web có thể tham chiếu tới các tài nguyên được lưu bên ngoài tài liệu SVG. Ví dụ, một SVG có thể chứa liên kết hình ảnh như `images/photo.png`, giá trị CSS `url(...)`, hoặc URL phông chữ. 

Để nhập nội dung SVG như vậy, tạo một triển khai [IExternalResourceResolver](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/iexternalresourceresolver/) và truyền nó, cùng với một base URI, vào một hàm tạo `SvgImage` thích hợp. Base URI xác định vị trí của tài liệu SVG và được dùng để giải quyết các liên kết tương đối. 

Giao diện [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) cung cấp quyền truy cập thông tin về SVG đã nhập:

- `get_SvgContent()` trả về mã SVG dưới dạng chuỗi. 
- `get_SvgData()` trả về nội dung SVG dưới dạng mảng byte. 
- `get_BaseUri()` trả về base URI được dùng cho các liên kết tương đối. 
- `get_ExternalResourceResolver()` trả về resolver được gán cho ảnh SVG. 

### **Triển khai bộ giải quyết tài nguyên bên ngoài**

Resolver có hai phương thức:

- [ResolveUri](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) kết hợp base URI và liên kết tài nguyên tương đối và trả về một URI tuyệt đối. Trả về chuỗi null khi không thể giải quyết liên kết hoặc không được phép. 
- [GetEntity](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) trả về một luồng đọc được cho một URI tài nguyên tuyệt đối. Trả về `nullptr` khi tài nguyên bị thiếu, bị chặn hoặc không có sẵn. Một luồng dự phòng cũng có thể được trả về khi phù hợp. 

Resolver dưới đây chỉ tải các tài nguyên được liên kết từ một thư mục cục bộ được phép. Các tài nguyên mạng và các đường dẫn ngoài thư mục cho phép sẽ bị chặn. Một hình ảnh dự phòng tùy chọn được trả về cho các liên kết hình ảnh không thể giải quyết.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Resolver này cố ý chỉ cho phép các tệp cục bộ.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Chỉ sử dụng dự phòng cho các tài nguyên hình ảnh. Trả về một luồng ảnh
        // đối với phông chữ hoặc stylesheet bị thiếu sẽ không hợp lệ.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Giải quyết tài nguyên liên kết trong quá trình nhập SVG**

Giả sử `assets/diagram.svg` chứa một tham chiếu tương đối như:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ví dụ C++ sau truyền URI của tệp SVG làm base URI và cung cấp một resolver tùy chỉnh. Resolver chuyển đổi liên kết hình ảnh tương đối thành URI tuyệt đối và trả về một luồng chứa tài nguyên liên kết trong khi Aspose.Slides xử lý SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// URI cơ sở đại diện cho vị trí của tài liệu SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Lớp `SvgImage` cũng cung cấp các overload cho phép chấp nhận dữ liệu SVG dưới dạng mảng byte hoặc luồng, cùng với một resolver tài nguyên bên ngoài và một base URI.

{{% alert title="Quan trọng" color="warning" %}}

Resolver tài nguyên cung cấp các tài nguyên bên ngoài trong khi Aspose.Slides xử lý và render SVG. Nó không sửa đổi mã SVG gốc hoặc tự động nhúng các tài nguyên đã giải quyết vào trong đó.

Khi một `ISvgImage` được thêm vào bộ sưu tập ảnh của bản trình chiếu, tệp PPTX có thể chứa cả biểu diễn SVG gốc và một hình raster dự phòng. Một tài nguyên được liên kết có thể xuất hiện trong hình dự phòng được tạo ra trong khi một liên kết tương đối như `images/photo.png` vẫn không thay đổi trong SVG được lưu. Vì vậy, một ứng dụng render biểu diễn SVG gốc có thể bỏ qua nội dung được liên kết khi tài nguyên bên ngoài gốc không khả dụng.

{{% /alert %}}

### **Tạo hình ảnh SVG di động**

Để tạo một hình ảnh SVG không phụ thuộc vào các tệp bên ngoài, làm cho SVG độc lập trước khi tạo `SvgImage`. Ví dụ, thay thế các URL hình ảnh được liên kết bằng các URI `data:` chứa dữ liệu hình ảnh:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Sau khi mọi tài nguyên cần thiết được nhúng vào nội dung SVG, tạo `SvgImage`, thêm nó vào bộ sưu tập ảnh của bản trình chiếu và chèn vào khung ảnh như trong ví dụ trước.

### **Xử lý tài nguyên bị thiếu hoặc bị chặn**

Trả về chuỗi null từ `ResolveUri` khi URI tài nguyên không hợp lệ, bị cấm hoặc không thể giải quyết. Trả về `nullptr` từ `GetEntity` khi tài nguyên không thể đọc được. Aspose.Slides sẽ tiếp tục xử lý SVG mà không có tài nguyên đó khi có thể.

Một luồng dự phòng có thể được trả về cho tài nguyên bị thiếu, nhưng nội dung của nó phải tương thích với loại tài nguyên được yêu cầu. Ví dụ, chỉ trả về luồng hình ảnh cho hình ảnh bị thiếu, không phải cho phông chữ hoặc stylesheet.

{{% alert title="Bảo mật" color="warning" %}}

Không giải quyết các đường dẫn tệp tùy ý hoặc URL mạng không giới hạn từ các tệp SVG không tin cậy. Hạn chế các scheme, thư mục và máy chủ được phép. Đối với tài nguyên mạng, cũng áp dụng thời gian chờ kết nối, giới hạn kích thước phản hồi và xác thực nội dung.

{{% /alert %}}

## **Chuyển đổi SVG thành một tập hợp các hình dạng**

Aspose.Slides có thể chuyển đổi một SVG thành một tập hợp các hình dạng, tương tự như chức năng tương ứng trong PowerPoint:

![Menu bật lên PowerPoint](img_01_01.png)

Chức năng này được cung cấp bởi một overload của phương thức [AddGroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/) của giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/) cho phép nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) làm đối số đầu tiên.

Đoạn mã mẫu C++ sau cho thấy cách sử dụng phương pháp này để chuyển đổi một tệp SVG thành một tập hợp các hình dạng:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Tên tệp SVG nguồn
auto svgFileName = System::String(u"sample.svg");

// Tên tệp bản trình chiếu đầu ra
auto outPptxPath = System::String(u"presentation.pptx");

// Tạo một bản trình chiếu mới
auto presentation = System::MakeObject<Presentation>();

// Đọc nội dung tệp SVG
auto svgContent = File::ReadAllText(svgFileName);

// Tạo một đối tượng SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Lấy kích thước slide
auto slideSize = presentation->get_SlideSize()->get_Size();

// Chuyển đổi hình ảnh SVG thành một nhóm các hình dạng và co giãn nó tới kích thước slide
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Lưu bản trình chiếu ở định dạng PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Thêm hình ảnh dưới dạng EMF vào slide**

Aspose.Slides cho C++ cho phép bạn tạo ảnh EMF từ các bảng tính Excel với Aspose.Cells và thêm chúng vào slide bản trình chiếu. 

Đoạn mã mẫu C++ sau cho thấy cách thực hiện điều này:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells cho C++ phải được khởi động trước khi sử dụng bất kỳ kiểu nào của nó.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render the worksheet as EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells trả về trang đã render dưới dạng bộ đệm, sau đó Aspose.Slides thêm nó như một hình ảnh.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Thay thế hình ảnh trong bộ sưu tập ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập ảnh của bản trình chiếu, bao gồm cả các hình ảnh được sử dụng bởi các hình dạng trên slide. Phần này mô tả một số cách cập nhật hình ảnh trong bộ sưu tập. Bạn có thể thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/), hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải tệp bản trình chiếu chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Tải một hình ảnh mới từ tệp vào một mảng byte.
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.
4. Trong cách tiếp cận thứ hai, tải hình ảnh vào một đối tượng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.
5. Trong cách tiếp cận thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập ảnh của bản trình chiếu.
6. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Cách thứ nhất.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Cách thứ hai.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Cách thứ ba.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Lưu bản trình chiếu vào tệp.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Thông tin" color="info" %}}

Với bộ chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt ảnh cho văn bản và tạo GIF từ văn bản. 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Độ phân giải gốc của hình ảnh có được giữ nguyên sau khi chèn không?**

Có. Các pixel gốc được giữ lại, nhưng diện mạo cuối cùng phụ thuộc vào cách [hình ảnh](/slides/vi/cpp/picture-frame/) được thu phóng trên slide và bất kỳ nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide một lúc là gì?**

Đặt logo trên slide master hoặc một layout và thay thế nó trong bộ sưu tập ảnh của bản trình chiếu — các cập nhật sẽ lan tới mọi phần tử sử dụng tài nguyên đó.

**Một SVG đã chèn có thể được chuyển đổi thành các hình dạng có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó từng phần sẽ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**Làm sao để đặt một hình ảnh làm nền cho nhiều slide cùng lúc?**

[Gán hình ảnh làm nền](/slides/vi/cpp/presentation-background/) trên slide master hoặc layout tương ứng — bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**Làm sao để ngăn bản trình chiếu trở nên quá lớn vì quá nhiều hình ảnh?**

Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi cần.