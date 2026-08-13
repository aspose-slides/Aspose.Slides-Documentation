---
title: Chuyển đổi PPT và PPTX sang JPG trong C++
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/cpp/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang JPG
- bản trình chiếu sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu PowerPoint dưới dạng JPG
- lưu bản trình chiếu dưới dạng JPG
- lưu slide dưới dạng JPG
- lưu PPT dưới dạng JPG
- lưu PPTX dưới dạng JPG
- xuất PPT sang JPG
- xuất PPTX sang JPG
- C++
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) thành ảnh JPG chất lượng cao trong C++ với Aspose.Slides bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Việc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang ảnh JPG giúp chia sẻ slide dễ dàng, tối ưu hiệu suất và nhúng nội dung vào trang web hoặc ứng dụng. Aspose.Slides for C++ cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với những tính năng này, bạn có thể dễ dàng triển khai trình xem bản trình chiếu riêng và tạo ảnh thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ slide khỏi việc sao chép hoặc trình diễn bản trình chiếu ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản trình chiếu hoặc một slide cụ thể sang các định dạng hình ảnh.

## **Chuyển Đổi Slide Bản Trình Chiếu Sang Ảnh JPG**

Dưới đây là các bước để chuyển đổi tệp PPT, PPTX hoặc ODP sang JPG:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Lấy đối tượng slide của kiểu [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) từ bộ sưu tập slide của bản trình chiếu.
3. Tạo ảnh của slide bằng phương thức [ISlide.GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/).
4. Gọi phương thức [IImage.Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/save/) trên đối tượng ảnh. Truyền tên tệp đầu ra và định dạng ảnh làm đối số.

{{% alert color="info" %}} 

**Lưu ý:** Việc chuyển đổi PPT, PPTX hoặc ODP sang JPG khác với chuyển đổi sang các định dạng khác trong API của Aspose.Slides for C++. Đối với các định dạng khác, bạn thường sử dụng phương thức [IPresentation.Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/). Tuy nhiên, đối với chuyển đổi JPG, bạn cần sử dụng phương thức [IImage.Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Tạo ảnh slide với tỷ lệ đã chỉ định.
    auto image = slide->GetImage(scaleX, scaleY);

    // Lưu ảnh vào đĩa ở định dạng JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Chuyển Đổi Slide Sang JPG Với Kích Thước Tùy Chỉnh**

Để thay đổi kích thước của các ảnh JPG kết quả, bạn có thể đặt kích thước ảnh bằng cách truyền vào phương thức [ISlide.GetImage(Size)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Điều này cho phép bạn tạo ảnh với giá trị chiều rộng và chiều cao cụ thể, đảm bảo đầu ra đáp ứng yêu cầu về độ phân giải và tỷ lệ khung hình. Tính linh hoạt này đặc biệt hữu ích khi tạo ảnh cho các ứng dụng web, báo cáo hoặc tài liệu, nơi cần kích thước ảnh chính xác.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Tạo ảnh slide với kích thước đã chỉ định.
    auto image = slide->GetImage(imageSize);

    // Lưu ảnh vào đĩa ở định dạng JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Hiển Thị Bình Luận Khi Lưu Slide Thành Hình Ảnh**

Aspose.Slides for C++ cung cấp tính năng cho phép bạn hiển thị bình luận trên các slide của bản trình chiếu khi chuyển đổi chúng thành ảnh JPG. Chức năng này rất hữu ích để giữ lại các chú thích, phản hồi hoặc thảo luận do cộng tác viên thêm vào bản trình chiếu PowerPoint. Bằng cách bật tùy chọn này, bạn đảm bảo rằng bình luận sẽ xuất hiện trong các ảnh được tạo, giúp việc xem xét và chia sẻ phản hồi trở nên dễ dàng hơn mà không cần mở tệp bản trình chiếu gốc.

Giả sử chúng ta có một tệp bản trình chiếu, "sample.pptx", với một slide chứa bình luận:

![Slide có bình luận](slide_with_comments.png)

Đoạn mã C++ sau chuyển đổi slide sang ảnh JPG trong khi giữ lại bình luận:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Đặt tùy chọn cho bình luận của slide.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Chuyển đổi slide đầu tiên thành ảnh.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Kết quả:

![Hình JPG có bình luận](image_with_comments.png)

## **Xem Thêm**

Xem các tùy chọn khác để chuyển đổi PPT, PPTX hoặc ODP sang ảnh, chẳng hạn:

- [Chuyển PowerPoint sang GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/)
- [Chuyển PowerPoint sang PNG](/slides/vi/cpp/convert-powerpoint-to-png/)
- [Chuyển PowerPoint sang TIFF](/slides/vi/cpp/convert-powerpoint-to-tiff/)
- [Chuyển PowerPoint sang SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Để xem cách Aspose.Slides chuyển đổi PowerPoint sang ảnh JPG, hãy thử các trình chuyển đổi trực tuyến miễn phí này: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/vi/conversion/pptx-to-jpg) và [PPT to JPG](https://products.aspose.app/slides/vi/conversion/ppt-to-jpg). 

{{% /alert %}}

![Trình Chuyển Đổi PPTX Sang JPG Trực Tuyến Miễn Phí](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose cung cấp một ứng dụng web [Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể ghép ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), v.v.

Bằng các nguyên tắc đã mô tả trong bài viết này, bạn có thể chuyển đổi ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, xem các trang sau: chuyển đổi [ảnh sang JPG](https://products.aspose.com/slides/vi/cpp/conversion/image-to-jpg/); chuyển đổi [JPG sang ảnh](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Câu Hỏi Thường Gặp**

### Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

### Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?

Có, Aspose.Slides hiển thị toàn bộ nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và hơn thế nữa. Tuy nhiên, độ chính xác khi render có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu phông chữ.

### Có bất kỳ giới hạn nào về số lượng slide có thể xử lý không?

Aspose.Slides tự nó không áp đặt giới hạn nghiêm ngặt nào về số lượng slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bản trình chiếu lớn hoặc ảnh có độ phân giải cao.