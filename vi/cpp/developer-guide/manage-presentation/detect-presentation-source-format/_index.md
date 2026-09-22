---
title: Xác định Định dạng Bản trình chiếu Gốc trong C++
linktitle: Định dạng nguồn
type: docs
weight: 35
url: /vi/cpp/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản trình chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Đọc định dạng gốc của bản trình chiếu đã tải trong C++ với Aspose.Slides cho C++, so sánh các API phát hiện và xử lý tệp, luồng và các định dạng kế thừa."
---
## **Tổng quan**

Sau khi tải một bản trình chiếu, hãy gọi [Presentation::get_SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sourceformat/) để xác định định dạng gốc của nó. Phương thức này cũng có sẵn qua [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sourceformat/). Sử dụng nó khi việc xử lý tiếp theo phụ thuộc vào định dạng mà thể hiện hiện tại đã được tải.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) được chọn cho tệp đầu ra. Lưu sang định dạng khác không thay đổi định dạng nguồn của thể hiện hiện có.

## **Đọc Định dạng Nguồn của Tệp**

Ví dụ này yêu cầu một tệp `sample.pptx` hiện có. Nó tải tệp và chọn một chính sách xử lý ứng dụng bằng cách sử dụng [Presentation::get_SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sourceformat/), thay vì dựa vào tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ này in ra chính sách được chọn; hãy thay thế các thông báo bằng logic ứng dụng của bạn.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Nhận dạng các Giá trị Hỗ trợ**

[SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sourceformat/) phân biệt các định dạng bản trình chiếu sau. Các phần mở rộng dưới đây là phần mở rộng thông thường, không phải là sự tái tạo lại tên tệp gốc.

| Giá trị SourceFormat | Phần mở rộng | Định dạng |
| --- | --- | --- |
| `Ppt` | `.ppt` | Bản trình chiếu PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Bản trình chiếu Office Open XML |
| `Pptm` | `.pptm` | Bản trình chiếu Office Open XML có hỗ trợ macro |
| `Pps` | `.pps` | Trình chiếu PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Trình chiếu Office Open XML |
| `Ppsm` | `.ppsm` | Trình chiếu Office Open XML có hỗ trợ macro |
| `Pot` | `.pot` | Mẫu PowerPoint 97–2003 |
| `Potx` | `.potx` | Mẫu Office Open XML |
| `Potm` | `.potm` | Mẫu Office Open XML có hỗ trợ macro |
| `Odp` | `.odp` | Bản trình chiếu OpenDocument |
| `Otp` | `.otp` | Mẫu trình chiếu OpenDocument |
| `Fodp` | `.fodp` | Bản trình chiếu Flat XML ODF |
| `Xml` | `.xml` | Bản trình chiếu PowerPoint XML |

## **Đọc Định dạng Nguồn của Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` hiện có. Đọc các byte của nó vào một luồng bộ nhớ mô phỏng đầu vào không có tên tệp, chẳng hạn như giá trị trong cơ sở dữ liệu hoặc mảng byte được tải lên. Hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chỉ nhận luồng.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS và POT sử dụng cùng một định dạng nhị phân cơ bản. Khi tải bằng đường dẫn tệp, phần mở rộng có thể giúp phân biệt trình chiếu hoặc mẫu. Khi không có tên tệp, nội dung PPS và POT cũ có thể được báo cáo là `SourceFormat::Ppt`; ví dụ PPS ở trên báo `Ppt`.

Nếu ứng dụng của bạn phải giữ sự khác biệt này, hãy lưu giữ tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là một gợi ý hữu ích cho các phụ loại cổ, nhưng không nên là cơ sở duy nhất để xác định nội dung bản trình chiếu bất kỳ.

## **So sánh việc phát hiện Trước và Sau khi tải**

Sử dụng [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentationfactory/getpresentationinfo/) và [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/get_loadformat/) khi bạn cần kiểm tra tệp trước khi tải toàn bộ mô hình đối tượng bản trình chiếu. Sử dụng [Presentation::get_SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sourceformat/) khi thể hiện đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra `Pptx` cho cả hai kiểm tra. Trong môi trường thực tế, chọn API phù hợp với giai đoạn xử lý của bạn; một bản trình chiếu đã được tải không cần kiểm tra thứ hai chỉ để lấy định dạng nguồn.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Kết quả có các kiểu liệt kê khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sourceformat/). Không so sánh chúng bằng cách ép kiểu giá trị số hoặc giả định rằng mọi định dạng có kết quả phát hiện giống nhau. PowerPoint XML có thể được báo cáo là `LoadFormat::Unknown` trước khi tải và `SourceFormat::Xml` sau khi tải.

## **Giữ Định dạng Nguồn và Định dạng Đầu ra Riêng biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra `Pptx` cả trước và sau khi lưu thể hiện gốc. Chỉ thể hiện mới được tải từ đầu ra ODP mới báo cáo `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Một bản trình chiếu được tạo từ đầu bằng `MakeObject<Presentation>()` báo cáo `SourceFormat::Pptx`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một thể hiện mới tạo, không phải bằng chứng rằng một tệp PPTX đã được tải. Theo dõi xem ứng dụng của bạn tạo hay tải thể hiện một cách riêng biệt nếu sự khác biệt này quan trọng.

## **Ánh xạ Định dạng Nguồn sang Phần mở rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mỗi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sourceformat/) hiện được hỗ trợ sang một phần mở rộng thông thường, mà không phân tích tên tệp đầu vào. Phương án dự phòng tránh việc tự động gán phần mở rộng cho giá trị không được nhận dạng.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Ánh xạ này không chuyển đổi tệp hoặc khôi phục lại phụ loại PPS/POT cổ bị mất khi tải từ luồng. Đối với việc lưu thực tế, hãy chọn một [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) một cách rõ ràng, hoặc sử dụng chuyển đổi được mô tả trong [Save Presentations in Their Original Format](/slides/vi/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Xác minh Định dạng bằng cách Lưu và Mở lại**

Ví dụ tự chứa này tạo một bản trình chiếu và ghi ba tệp trong thư mục làm việc, ghi đè các tệp cùng tên. Nó mở lại mỗi đầu ra vừa bằng đường dẫn vừa bằng luồng bộ nhớ. Đối với PPTX và ODP, cả hai cách đều báo cáo định dạng đã lưu. Đối với PPS, tải bằng đường dẫn báo `Pps`, trong khi tải cùng các byte mà không có tên tệp báo `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

| Định dạng đã lưu | SourceFormat từ đường dẫn tệp | SourceFormat từ luồng không tên |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` tương ứng | Giống như đường dẫn tệp |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` tương ứng | Giống như đường dẫn tệp |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` tương ứng | Giống như đường dẫn tệp |
| ODP, OTP | `Odp`, `Otp` tương ứng | Giống như đường dẫn tệp |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Nội dung PPS/POT cổ được chuẩn hoá thành `Ppt` cho các luồng không có tên. Bảng mô tả cách xác định định dạng, không phải cách bảo tồn mọi tính năng của bản trình chiếu trong quá trình chuyển đổi.

## **Câu hỏi thường gặp**

**Lưu sang ODP có thay đổi định dạng nguồn của bản trình chiếu đã được tải từ PPTX không?**

Không. Thể hiện hiện tại vẫn báo `Pptx`. Một thể hiện được tải từ tệp ODP đã lưu sẽ báo `Odp`.

**Luồng có luôn phân biệt được bản trình chiếu cổ, trình chiếu và mẫu không?**

Không. PPT, PPS và POT chia sẻ cùng định dạng nhị phân. Hãy giữ tên tệp hoặc siêu dữ liệu phụ loại riêng khi cần sự phân biệt này.

**Nên dùng API nào nếu bản trình chiếu đã được tải?**

Đọc [Presentation::get_SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sourceformat/). Sử dụng [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentationfactory/getpresentationinfo/) để kiểm tra trước khi tải.