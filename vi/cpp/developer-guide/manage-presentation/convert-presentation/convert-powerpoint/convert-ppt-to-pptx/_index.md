---
title: Chuyển đổi PPT sang PPTX trong C++
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/cpp/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT thành PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Chuyển đổi các tệp PPT legacy sang PPTX trong C++ bằng Aspose.Slides. Bao gồm các ví dụ C++ cho việc chuyển đổi một tệp hoặc hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân legacy, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for C++ có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này hướng dẫn cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau quá trình chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) , sau đó gọi [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/). Giải phóng đối tượng presentation khi không còn cần thiết để giải phóng tài nguyên.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lần chuyển đổi thất bại sẽ không làm dừng phần còn lại của lô.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định có cho phép ghi đè tệp đầu ra đã tồn tại hay không, và ghi các tên tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà không cung cấp mật khẩu đúng, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể làm cho quá trình chuyển đổi thất bại. Xem [Password-Protected Presentations](/slides/vi/cpp/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ trung thực và tính năng legacy**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không biểu diễn mọi tính năng theo cùng một cách. Một tính năng legacy không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể bị chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, hiệu ứng chuyển tiếp, đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến, hoặc macro VBA. Tệp PPTX thuần không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro phù hợp khi VBA cần phải khả dụng. Đồng thời xác minh rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường nơi bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, hãy mở lại tệp PPTX đã tạo bằng cách lập trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự định. Đừng coi một lời gọi thành công của [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) là bằng chứng cho rằng mọi tính năng legacy đều có bản đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân legacy. Giữ bản PPT gốc làm bản lưu trữ hoặc sao lưu cho tới khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc định dạng đầu ra khác, hãy sử dụng hướng dẫn cụ thể cho định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/cpp/convert-presentation/) thay vì giả định rằng mọi mục tiêu đều giữ nguyên các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt, hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API C++.

## **Bài viết liên quan**

- [Lưu bản trình chiếu trong C++](/slides/vi/cpp/save-presentation/)
- [Định dạng tệp được hỗ trợ](/slides/vi/cpp/supported-file-formats/)
- [Mở bản trình chiếu trong C++](/slides/vi/cpp/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**  
Có. Aspose.Slides for C++ tải và lưu các tệp trình chiếu mà không cần Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**  
Nó giữ nguyên nội dung trình chiếu phổ biến, nhưng độ trung thực tuyệt đối không được đảm bảo cho mọi tính năng legacy hoặc không được hỗ trợ. Hãy xem lại tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh đặc biệt, hoặc phông chữ không phổ biến.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**  
Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu hoặc sai mật khẩu sẽ khiến thao tác tải thất bại.

**Tôi có nên xóa tệp PPT sau khi chuyển đổi không?**  
Giữ nguyên tệp gốc cho đến khi bạn đã kiểm chứng PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp một bản sao sao lưu nếu tính năng legacy chuyển đổi khác đi.