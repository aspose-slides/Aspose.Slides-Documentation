---
title: "Tạo bài thuyết trình bằng C++"
linktitle: "Tạo bài thuyết trình"
type: docs
weight: 10
url: /vi/cpp/create-presentation/
keywords:
- tạo bài thuyết trình
- bài thuyết trình mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tạo bài thuyết trình bằng C++ với Aspose.Slides - tạo các tệp PPT, PPTX và ODP, tận dụng hỗ trợ OpenDocument, và lưu chúng bằng chương trình để có kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bài thuyết trình trong Aspose.Slides, thêm một hộp văn bản vào slide đầu tiên và lưu kết quả thành tệp. Một phần FAQ ngắn ở cuối đề cập đến các câu hỏi phổ biến về định dạng, mẫu, kích thước slide, đơn vị, sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

Trước khi bắt đầu, thêm Aspose.Slides vào dự án của bạn: qua NuGet trong dự án Visual Studio trên Windows, hoặc từ gói ZIP với CMake trên Linux. Xem [Cài đặt](/slides/vi/cpp/installation/).

## **Tạo bài thuyết trình PowerPoint**

Để tạo một bài thuyết trình và đặt hộp văn bản trên slide đầu tiên, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Một bài thuyết trình mới đã chứa sẵn một slide trống.
1. Lấy slide đó bằng phương thức [Presentation::get_Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slide/) và chỉ số của nó, 0.
1. Thêm một hình chữ nhật bằng phương thức [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addautoshape/), và đặt văn bản cho nó bằng phương thức [ITextFrame::set_Text](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/set_text/).
1. Lưu bài thuyết trình thành tệp PPTX bằng phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Góc trên‑trái của hình chữ nhật cách mép trái 50 điểm và cách mép trên 50 điểm của slide, và hình chữ nhật rộng 400 điểm, cao 100 điểm. Chương trình lưu *hello.pptx* trong thư mục làm việc, với một slide chứa hình chữ nhật và văn bản của nó. Khi không có giấy phép, Aspose.Slides cũng sẽ thêm dấu bản quyền đánh giá vào mỗi slide được lưu; xem [Cấp phép](/slides/vi/cpp/licensing/).

## **Câu hỏi thường gặp**

### Những định dạng nào tôi có thể lưu một bài thuyết trình mới?

Bạn có thể lưu thành [PPTX, PPT và ODP](/slides/vi/cpp/save-presentation/), và xuất ra [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/vi/cpp/convert-powerpoint-to-xps/), [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), [SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), và [hình ảnh](/slides/vi/cpp/convert-powerpoint-to-png/), cùng các định dạng khác.

### Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và tương tự [được hỗ trợ](/slides/vi/cpp/supported-file-formats/).

### Làm sao tôi kiểm soát kích thước/tỷ lệ khung hình khi tạo bài thuyết trình?

Đặt [kích thước slide](/slides/vi/cpp/slide-size/) (bao gồm các preset như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung được thu phóng.

### Các kích thước và tọa độ được đo bằng đơn vị nào?

Bằng điểm: 1 inch tương đương 72 đơn vị.

### Làm sao tôi xử lý các bài thuyết trình rất lớn (có nhiều tệp media) để giảm việc dùng bộ nhớ?

Sử dụng [chiến lược quản lý BLOB](/slides/vi/cpp/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp thay vì chỉ dùng luồng trong bộ nhớ.

### Tôi có thể tạo/lưu các bài thuyết trình song song không?

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/cpp/multithreading/). Chạy các thể hiện riêng biệt, cách ly cho mỗi luồng hoặc tiến trình.

### Làm sao loại bỏ dấu bản quyền dùng thử và các giới hạn?

[Áp dụng giấy phép](/slides/vi/cpp/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị sửa đổi, và việc thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng cùng tham gia.

### Tôi có thể ký số PPTX mà tôi tạo không?

Có. [Chữ ký số](/slides/vi/cpp/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bài thuyết trình.

### Các macro (VBA) có được hỗ trợ trong các bài thuyết trình được tạo không?

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/cpp/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.