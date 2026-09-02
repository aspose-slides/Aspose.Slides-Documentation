---
title: Chuyển đổi PowerPoint sang XML trong C++
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/cpp/convert-powerpoint-to-xml/
keywords:
- chuyển đổi PowerPoint sang XML
- chuyển đổi bài thuyết trình sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- PowerPoint XML Presentation
- SaveFormat::Xml
- lưu bài thuyết trình dưới dạng XML
- xuất bài thuyết trình sang XML
- luồng XML
- C++
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PowerPoint và OpenDocument sang tệp hoặc luồng XML PowerPoint trong C++ bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ có thể chuyển đổi các bài thuyết trình PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần một biểu diễn dựa trên văn bản để kiểm tra cấu trúc bài thuyết trình, khắc phục sự cố các tài liệu đã tạo, so sánh đầu ra trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì một gói bài thuyết trình.

Sử dụng phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) với giá trị `Xml` từ enumeration [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào một luồng.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` tạo một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn như `ppt/presentation.xml` hoặc các tệp XML của slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.
{{% /alert %}}

## **Chuyển đổi bài thuyết trình sang tệp XML**

Tải một bài thuyết trình nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và sau đó truyền đường dẫn đầu ra cùng với `SaveFormat::Xml` tới [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/). Nguồn có thể là bất kỳ định dạng bài thuyết trình nào được hỗ trợ để tải, chẳng hạn như PPT, PPTX hoặc ODP.

Ví dụ sau chuyển đổi một bài thuyết trình PPTX sang tệp XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Ghi đầu ra XML vào một luồng**

Sử dụng phiên bản overload cho luồng của [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) khi XML cần được giữ trong bộ nhớ hoặc được truyền tới thành phần khác, chẳng hạn như dịch vụ web, nhà cung cấp lưu trữ, hoặc pipeline xử lý XML. Ví dụ sau ghi kết quả vào một [MemoryStream](https://reference.aspose.com/slides/vi/cpp/system.io/memorystream/) và đưa con trỏ trở lại đầu để đọc tiếp:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Chuyển xmlStream tới thành phần tiếp theo trong quy trình làm việc.
```

## **So sánh XML với các định dạng bài thuyết trình và xuất**

Chọn định dạng đầu ra dựa trên cách kết quả sẽ được sử dụng:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Một PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo, và tích hợp dựa trên XML |
| PPT (`.ppt`) | Một tệp bài thuyết trình nhị phân cổ điển | Tương thích với các quy trình PowerPoint cũ |
| PPTX (`.pptx`) | Một gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thông thường và trao đổi bài thuyết trình |
| PDF or TIFF | Các trang bố cục cố định hoặc hình ảnh đa trang | Xem, in ấn và lưu trữ |
| PNG, JPEG, or SVG | Mô tả đã render của một slide riêng lẻ | Hình ảnh thu nhỏ, xem trước và tài nguyên hình ảnh |
| HTML or HTML5 | Đầu ra bài thuyết trình dạng web | Xem trên trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu được sử dụng cho việc kiểm tra và các quy trình làm việc hướng dữ liệu. Khác với PDF, TIFF, HTML và các định dạng hình ảnh slide, nó biểu diễn dữ liệu bài thuyết trình thay vì render các slide thành trang hoặc tài sản hình ảnh. Bảng [định dạng tệp được hỗ trợ](/slides/vi/cpp/supported-file-formats/) liệt kê PowerPoint XML Presentation như một định dạng chỉ lưu, vì vậy không nên sử dụng nó khi một quy trình làm việc cần tải lại tệp đã xuất vào Aspose.Slides để tiếp tục chỉnh sửa.

## **Câu hỏi thường gặp**

**`SaveFormat::Xml` có giống như việc lưu một tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat::Xml` tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng có thể ghi được vào [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/). Ví dụ, sử dụng một [MemoryStream](https://reference.aspose.com/slides/vi/cpp/system.io/memorystream/) để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ được hỗ trợ để lưu, không hỗ trợ tải. Sử dụng PPTX hoặc một định dạng bài thuyết trình được hỗ trợ khác khi cần chỉnh sửa vòng vòng.

**Quá trình chuyển đổi XML có render mỗi slide thành trang hoặc hình ảnh không?**

Không. Chuyển đổi XML ghi dữ liệu bài thuyết trình có cấu trúc. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho hình ảnh của từng slide.