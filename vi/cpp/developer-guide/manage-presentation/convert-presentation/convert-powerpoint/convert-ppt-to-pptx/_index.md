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
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Chuyển đổi các tệp PPT kế thừa sang PPTX trong C++ với Aspose.Slides. Bao gồm các ví dụ C++ cho việc chuyển đổi từng tệp và hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân kế thừa, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for C++ có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này trình bày cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

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

Đuôi tệp không tự động xác định định dạng đầu ra; đối số [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ dưới đây chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi sẽ không làm dừng toàn bộ lô.

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

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định xem có nên ghi đè tệp đầu ra đã tồn tại hay không, và ghi tên các tệp bị lỗi vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà không cung cấp mật khẩu cần thiết, các đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể khiến việc chuyển đổi thất bại. Xem [Password-Protected Presentations](/cpp/password-protected-presentation/) để tải các tệp được mã hoá.

## **Độ trung thực và các tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách. Một tính năng kế thừa không có tương đương trong PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác nhau.

Hãy kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển cảnh, các đối tượng OLE được nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ hiếm hoặc macro VBA. Tệp PPTX thông thường không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần được duy trì. Đồng thời, xác nhận rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường mà bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, mở lại tệp PPTX đã tạo bằng cách lập trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự kiến. Đừng coi một lời gọi [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) thành công là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện nay, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ dưới dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân kế thừa. Giữ bản PPT gốc làm bản lưu trữ hoặc sao lưu cho đến khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc kiểu đầu ra khác, hãy sử dụng hướng dẫn theo định dạng trong [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) thay vì cho rằng mọi đích đến đều bảo lưu các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với một tệp không thường xuyên hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API C++.

## **Bài viết liên quan**

- [Lưu bản trình chiếu trong C++](/cpp/save-presentation/)
- [Định dạng tệp được hỗ trợ](/cpp/supported-file-formats/)
- [Mở bản trình chiếu trong C++](/cpp/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for C++ tải và lưu các tệp trình chiếu mà không cần Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có bảo toàn toàn bộ nội dung một cách chính xác không?**

Nó bảo toàn nội dung chung của bản trình chiếu, nhưng độ trung thực tuyệt đối không được đảm bảo cho mọi tính năng kế thừa hoặc không được hỗ trợ. Xem lại tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên biệt hoặc phông chữ hiếm.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu hoặc nhập sai mật khẩu sẽ khiến quá trình tải thất bại.

**Tôi có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ nguyên tệp gốc cho đến khi bạn xác minh PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp bản sao dự phòng nếu tính năng kế thừa chuyển đổi khác nhau.