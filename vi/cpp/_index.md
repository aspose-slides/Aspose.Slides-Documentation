---
title: Aspose.Slides cho C++
second_title: Aspose.Slides cho C++
type: docs
weight: 30
url: /vi/cpp/
keywords:
- tài liệu
- xử lý bản trình bày
- chuyển đổi bản trình bày
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Bắt đầu ở đây: cài đặt Aspose.Slides cho C++, tạo bản trình bày đầu tiên và tìm các hướng dẫn cho các nhiệm vụ thường gặp, tham chiếu API và hỗ trợ."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ là một thư viện C++ gốc để tạo, đọc, chỉnh sửa và chuyển đổi các bản trình bày PowerPoint và OpenDocument, mà không cần Microsoft PowerPoint hay Office Automation.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể có macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/cpp/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/cpp/create-presentation/">Tạo bản trình bày đầu tiên</a></li>
<li><a href="/slides/vi/cpp/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/cpp/supported-file-formats/">Các định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/cpp/evaluate-aspose-slides/">Giới hạn bản dùng thử</a></li>
<li><a href="/slides/vi/cpp/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÁC NHIỆM VỤ PHỔ BIẾN</p>
<ul>
<li><a href="/slides/vi/cpp/open-presentation/">Mở một bản trình bày</a></li>
<li><a href="/slides/vi/cpp/save-presentation/">Lưu một bản trình bày</a></li>
<li><a href="/slides/vi/cpp/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/cpp/convert-slide/">Kết xuất các slide thành hình ảnh</a></li>
<li><a href="/slides/vi/cpp/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH LÀM VIỆC VỚI SLIDES</p>
<ul>
<li><a href="/slides/vi/cpp/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/cpp/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/cpp/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/cpp/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/cpp/merge-presentation/">Hợp nhất các bản trình bày</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/cpp/examples/">Ví dụ theo phần tử slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Ví dụ trên GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Tham khảo API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/cpp/known-issues/">Các vấn đề đã biết</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trung tâm hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bản trình bày đầu tiên của bạn**

Trên Windows, tạo một dự án **Console App** C++ trong Visual Studio và cài đặt gói NuGet trong Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Trên Linux, tải gói ZIP cho Linux và thiết lập dự án CMake như mô tả trong [Installation](/slides/vi/cpp/installation/#linux).

Sau đó, sử dụng đoạn mã này làm tệp nguồn chính của chương trình. Nó sẽ tạo một bản trình bày với một ô văn bản và lưu lại:

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

Để chạy trên Windows, chọn nền tảng **x64** trên thanh công cụ và nhấn **Ctrl+F5**. Trên Linux, lưu nó dưới dạng *main.cpp* trong thư mục dự án, sau đó biên dịch và chạy ở đó:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Chương trình sẽ lưu *hello.pptx* với một slide chứa một ô văn bản. Nếu không có giấy phép, tệp đã lưu sẽ có dấu nước đánh giá — xem [Licensing](/slides/vi/cpp/licensing/). Để biết thêm cách tạo và điền nội dung vào bản trình bày, xem [Create Presentations](/slides/vi/cpp/create-presentation/).