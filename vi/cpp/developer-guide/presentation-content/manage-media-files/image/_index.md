---
title: Tối ưu hóa quản lý hình ảnh trong bản trình chiếu bằng C++
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/cpp/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thay thế hình ảnh
- bộ sưu tập hình ảnh
- khung ảnh
- hình ảnh liên kết
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- SVG thành hình dạng
- tài nguyên SVG bên ngoài
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý hình ảnh raster và SVG trong các bản trình chiếu PowerPoint và OpenDocument với Aspose.Slides cho C++."
---
## **Giới thiệu**

Aspose.Slides cho C++ cung cấp nhiều cách để làm việc với hình ảnh, mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ một hình ảnh trong bản trình chiếu, hiển thị nó trong khung ảnh, sử dụng nó làm nền slide, liên kết tới hình ảnh bên ngoài, thay thế tài nguyên hình ảnh được chia sẻ, hoặc chuyển nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào tài nguyên hình ảnh và cách chúng được sử dụng trong toàn bộ bản trình chiếu. Đối với việc cắt, trong suốt, hiệu ứng, kéo dài và các định dạng khác được áp dụng cho một khung ảnh riêng lẻ, xem [Khung ảnh](/slides/vi/cpp/picture-frame/).

## **Hiểu mô hình hình ảnh**

Các khái niệm API sau liên quan chặt chẽ nhưng không thể thay thế cho nhau:

- [bộ sưu tập hình ảnh của bản trình chiếu](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/) lưu trữ các tài nguyên hình ảnh được sử dụng trong bản trình chiếu. Sử dụng [IImageCollection::AddImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/addimage/) để thêm dữ liệu hình ảnh và nhận một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/).
- Một [khung ảnh](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) là một hình dạng hiển thị hình ảnh trên slide, bố cục hoặc master. Sử dụng [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addpictureframe/) để đặt tài nguyên hình ảnh lên một slide.
- Nền slide sử dụng hình ảnh như một phần của việc lấp đầy slide thay vì là một hình dạng. Do đó, nó không hoạt động giống như một khung ảnh.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/replaceimage/) thay thế một tài nguyên hình ảnh. Nếu nhiều thành phần trong bản trình chiếu sử dụng tài nguyên đó, chúng tất cả sẽ sử dụng bản thay thế.
- Chuyển đổi SVG thành các hình dạng tạo ra các hình dạng slide có thể chỉnh sửa. Sau khi chuyển đổi, nội dung không còn được quản lý như một tài nguyên hình ảnh duy nhất.

Do đó, quy trình làm việc điển hình là: thêm dữ liệu hình ảnh vào bộ sưu tập hình ảnh, nhận một [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/), và sau đó sử dụng tài nguyên đó trong một hoặc nhiều khung ảnh hoặc phần lấp đầy.

## **Thêm hình ảnh nhúng**

Để chèn một hình ảnh cục bộ, đọc tệp, thêm dữ liệu của nó vào bộ sưu tập hình ảnh và tạo một khung ảnh sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) trả về.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hình ảnh được thêm theo cách này được nhúng trong bản trình chiếu, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm hình ảnh từ web**

Khi một hình ảnh có sẵn qua HTTP hoặc HTTPS, tải xuống các byte của nó, thêm chúng vào bộ sưu tập hình ảnh của bản trình chiếu, và sử dụng tài nguyên hình ảnh trả về tương tự như hình ảnh cục bộ.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Xác thực URL từ xa, kích thước phản hồi và kiểu nội dung khi nguồn không đáng tin cậy. Trong các ứng dụng đã sử dụng một client HTTP khác, bạn có thể tải hình ảnh bằng client đó và truyền các byte hoặc luồng kết quả cho [IImageCollection::AddImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/addimage/).

## **Tái sử dụng hình ảnh trên nhiều slide**

Nếu cùng một hình ảnh cần được sử dụng hơn một lần, thêm nó vào bản trình chiếu một lần và tái sử dụng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) khi tạo các khung ảnh bổ sung. Điều này tránh việc tải lại cùng dữ liệu nguồn và làm cho mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các lần sử dụng của nó trở nên rõ ràng.

Đối với các đồ họa cần xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy cân nhắc đặt khung ảnh trên một [slide master](/slides/vi/cpp/slide-master/) hoặc bố cục thay vì thêm một hình dạng tương đương vào từng slide.

## **Sử dụng hình ảnh làm nền slide**

Một hình ảnh nền được gán cho phần lấp đầy slide; nó không được thêm như một hình dạng khung ảnh. Điều này hữu ích khi hình ảnh cần bao phủ nền slide và không nên được thao tác như một đối tượng slide thông thường.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Đối với các tùy chọn nền bổ sung, bao gồm nền master và bố cục, xem [Nền bản trình chiếu](/slides/vi/cpp/presentation-background/).

## **Hình ảnh nhúng và hình ảnh liên kết**

Embedded and linked images have different portability and file-size tradeoffs:

- **Hình ảnh nhúng:** dữ liệu hình ảnh được lưu trong bản trình chiếu. Bản trình chiếu độc lập, nhưng kích thước tệp bao gồm dữ liệu hình ảnh.
- **Hình ảnh liên kết:** bản trình chiếu lưu trữ đường dẫn hoặc URL tới một hình ảnh bên ngoài. Điều này có thể giảm kích thước bản trình chiếu, nhưng tài nguyên bên ngoài phải vẫn có thể truy cập khi bản trình chiếu được mở hoặc hiển thị.

Một hình ảnh liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài thông qua [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/set_linkpathlong/) thay vì nhúng dữ liệu hình ảnh.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể truy cập đáng tin cậy tài nguyên bên ngoài. Đối với các bản trình chiếu cần hoạt động offline hoặc di chuyển giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm việc với hình ảnh SVG**

SVG là định dạng vector, vì vậy nó hữu ích cho biểu tượng, sơ đồ và các đồ họa khác cần phóng to mà không mất chi tiết như hình ảnh raster. Aspose.Slides hỗ trợ SVG cả như một tài nguyên hình ảnh và như nguồn cho các hình dạng slide có thể chỉnh sửa.

### **Thêm SVG làm hình ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/svgimage/), thêm nó vào bộ sưu tập hình ảnh, và đặt tài nguyên hình ảnh kết quả vào một khung ảnh.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Tệp SVG với tài nguyên bên ngoài**

Một SVG có thể tham chiếu đến các hình ảnh, stylesheet hoặc phông chữ bên ngoài. Đối với những trường hợp này, [SvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/svgimage/) cung cấp các constructor nhận một [IExternalResourceResolver](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/iexternalresourceresolver/) và một URI cơ sở. Bộ giải quyết có thể ánh xạ một URI tương đối sang một URI tuyệt đối được phép và trả về một luồng cho tài nguyên được yêu cầu.

Bộ giải quyết làm cho các tài nguyên bên ngoài có sẵn trong khi Aspose.Slides xử lý SVG, nhưng nó không ghi lại SVG thành một tài liệu tự chứa. Nếu SVG cần duy trì tính di động, hãy nhúng các tài nguyên cần thiết vào chính SVG, ví dụ bằng cách sử dụng URI `data:` cho các hình ảnh liên kết.

Khi các tệp SVG xuất phát từ nguồn không đáng tin cậy, hạn chế các scheme, vị trí tệp và máy chủ mà bộ giải quyết có thể truy cập. Bộ giải quyết mạng cũng nên áp dụng thời gian chờ, giới hạn kích thước phản hồi và xác thực nội dung.

### **Chuyển đổi SVG thành các hình dạng có thể chỉnh sửa**

Aspose.Slides có thể chuyển đổi một SVG thành một nhóm các hình dạng slide có thể chỉnh sửa, tương tự như lệnh PowerPoint tương ứng.

![PowerPoint Popup Menu](img_01_01.png)

Sử dụng overload [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addgroupshape/) nhận một [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) để thực hiện chuyển đổi.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sử dụng chuyển đổi SVG‑to‑shapes khi các phần tử vector riêng lẻ cần được chỉnh sửa dưới dạng các hình dạng PowerPoint. Nếu SVG chỉ cần hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh tạo ra nhiều hình dạng riêng biệt.

## **Thay thế một tài nguyên hình ảnh hiện có**

Sử dụng [IPPImage::ReplaceImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/replaceimage/) khi bạn muốn thay thế một tài nguyên hình ảnh hiện có. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Nếu nhiều khung ảnh, nền, master hoặc bố cục sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên đó sẽ cập nhật tất cả các lần sử dụng. Nếu chỉ một khung ảnh cần thay đổi, hãy gán một hình ảnh khác cho khung đó thay vì thay thế tài nguyên chia sẻ.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/replaceimage/) cũng cung cấp các overload nhận một [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) hoặc một [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) khác.

## **Hướng dẫn quản lý hình ảnh thực tiễn**

### **Kiểm soát kích thước bản trình chiếu**

Các hình ảnh raster lớn có thể làm cho bản trình chiếu trở nên quá lớn. Sử dụng hình ảnh nguồn có kích thước phù hợp với kích thước hiển thị dự định, tái sử dụng các tài nguyên hình ảnh chia sẻ khi có thể, và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải đầy đủ.

Đối với các hình ảnh raster đã được đặt trong các khung ảnh, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/compressimage/) có thể giảm dữ liệu hình ảnh dựa trên độ phân giải và cài đặt cắt đã chọn. Đây là xử lý khung ảnh chứ không phải quản lý bộ sưu tập hình ảnh, vì vậy xem [Khung ảnh](/slides/vi/cpp/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn giữa nội dung nhúng và liên kết**

Việc nhúng làm cho bản trình chiếu di động vì tất cả dữ liệu hình ảnh cần thiết đi kèm với tệp. Việc liên kết có thể giảm kích thước tệp, nhưng nó tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái sử dụng thương hiệu chia sẻ**

Đối với các logo, watermark hoặc đồ họa trang trí lặp lại, sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bản trình chiếu hơn là nội dung slide, đặt nó trên một master hoặc layout để nó được kế thừa bởi các slide phù hợp.

### **Giữ tài nguyên SVG di động**

Một SVG tự chứa dễ dàng di chuyển và hiển thị nhất quán hơn so với SVG phụ thuộc vào các tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển đổi SVG thành các hình dạng chỉ khi các phần tử vector riêng lẻ cần được chỉnh sửa.

### **Sử dụng API hình ảnh Aspose.Slides**

Đối với quy trình làm việc hình ảnh C++, sử dụng các API Aspose.Slides [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) và [Images](https://reference.aspose.com/slides/vi/cpp/aspose.slides/images/) khi bạn cần một đối tượng hình ảnh, và sử dụng [IImageCollection::AddImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/addimage/) khi bạn cần đăng ký dữ liệu hình ảnh dưới dạng tài nguyên bản trình chiếu. Các overload của bộ sưu tập cũng hỗ trợ mảng byte và luồng, hữu ích khi dữ liệu hình ảnh đến từ tệp, client mạng, cơ sở dữ liệu hoặc các thư viện khác.

Tạo nội dung EMF từ bảng tính hoặc sản phẩm khác là một quy trình tích hợp riêng và nằm ngoài phạm vi của bài viết này. Nếu một tệp WMF hoặc EMF hiện có chỉ cần được chèn vào bản trình chiếu, truyền dữ liệu của nó tới một overload thích hợp của [IImageCollection::AddImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/addimage/) mà không thêm phụ thuộc sản phẩm thứ hai vào quy trình quản lý hình ảnh.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa bộ sưu tập hình ảnh và khung ảnh là gì?**

Bộ sưu tập hình ảnh lưu trữ các tài nguyên hình ảnh có thể tái sử dụng. Khung ảnh là một hình dạng slide hiển thị một trong các tài nguyên đó và cung cấp các định dạng đặc thù cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [IPPImage::ReplaceImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/replaceimage/). Đối với thương hiệu toàn bộ bản trình chiếu, đặt logo trên một master hoặc layout cũng có thể giảm nội dung slide trùng lặp.

**Tại sao hình ảnh liên kết lại biến mất trên máy tính khác?**

Một hình ảnh liên kết phụ thuộc vào tệp hoặc URL bên ngoài của nó. Nếu tài nguyên đó không thể truy cập được từ máy tính khác, hình ảnh liên kết có thể không khả dụng. Nhúng hình ảnh khi bản trình chiếu phải tự chứa.

**Có thể chỉnh sửa SVG chèn vào dưới dạng các hình dạng PowerPoint không?**

Có. Chuyển đổi SVG bằng [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addgroupshape/); nhóm kết quả chứa các hình dạng slide có thể chỉnh sửa thay vì một hình SVG duy nhất.

**Làm sao để giữ các bản trình chiếu có nhiều hình ảnh nhỏ hơn?**

Tái sử dụng các tài nguyên hình ảnh chia sẻ, tránh các nguồn raster quá lớn không cần thiết, nén các hình raster phù hợp khi cần, giữ các thương hiệu lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài được chấp nhận.