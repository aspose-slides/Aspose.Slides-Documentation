---
title: Lưu bản thuyết trình bằng C++
linktitle: Lưu Bản Thuyết Trình
type: docs
weight: 80
url: /vi/cpp/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản thuyết trình thành tệp
- bản thuyết trình thành luồng
- kiểu xem được định trước
- Định dạng Office Open XML Strict
- chế độ Zip64
- làm mới thumbnail
- tiến độ lưu
- C++
- Aspose.Slides
description: "Lưu các bản thuyết trình PowerPoint và OpenDocument vào tệp hoặc luồng trong C++ với Aspose.Slides, và cấu hình đầu ra PPTX và báo cáo tiến độ."
---
## **Tổng quan**

Sau khi bạn tạo một bản thuyết trình hoặc [mở một bản hiện có](/slides/vi/cpp/open-presentation/), hãy sử dụng phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) để ghi kết quả. Aspose.Slides cho C++ có thể lưu bản thuyết trình vào tệp hoặc luồng ở các định dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần sau đây đề cập đến các thao tác lưu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu bản thuyết trình vào tệp**

Để lưu một bản thuyết trình vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) cho phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/). Giá trị định dạng xác định loại tệp mà Aspose.Slides tạo ra.

Ví dụ sau tạo một bản thuyết trình và lưu nó dưới dạng tệp PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Thêm hoặc chỉnh sửa nội dung bản thuyết trình ở đây.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lưu bản thuyết trình ở định dạng gốc**

Đối với các ví dụ phát hiện tệp và luồng, hành vi của các bản thuyết trình mới tạo và sự khác biệt giữa định dạng nguồn và đầu ra, xem mục [Determine the Original Presentation Format](/slides/vi/cpp/detect-presentation-source-format/).

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể không được biết trước. Sau khi tải một tệp, đọc định dạng gốc của nó bằng [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_sourceformat/). Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sourceformat/) thu được cho [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/tosaveformat/) để lấy giá trị [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) tương ứng, sau đó sử dụng [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) để ghi bản thuyết trình đã chỉnh sửa.

Ví dụ đầy đủ sau xử lý mọi tệp trong thư mục đầu vào, cập nhật tiêu đề và lưu chúng vào thư mục đầu ra ở định dạng đã được tải:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/tosaveformat/) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bản thuyết trình tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bản thuyết trình; không được dùng để chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sourceformat/) không được hỗ trợ hoặc không hợp lệ sẽ gây ra một [ArgumentException](https://reference.aspose.com/slides/vi/cpp/system/argumentexception/).

Các tệp PPT, PPS và POT cổ điển sử dụng cùng một container nhị phân. Khi một bản thuyết trình như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể bị nhận dạng là PPT. Nếu cần giữ nguyên các kiểu phụ cổ điển này, hãy lưu tên tệp gốc hoặc siêu dữ liệu định dạng riêng và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu bản thuyết trình vào luồng**

Để ghi một bản thuyết trình mà không dựa vào đường dẫn tệp cuối cùng, truyền một [Stream](https://reference.aspose.com/slides/vi/cpp/system.io/stream/) có khả năng ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/) cho phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/). Cách này hữu ích khi đầu ra phải được trả về từ một dịch vụ web, lưu trong cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bản thuyết trình mới vào luồng tệp:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Lưu bản thuyết trình với Kiểu xem được định trước**

Bạn có thể chỉ định chế độ xem mà PowerPoint sẽ mở bản thuyết trình đã lưu ban đầu. Gọi [ViewProperties::set_LastView](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/set_lastview/) với một giá trị [ViewType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình chế độ xem Slide Master làm chế độ xem ban đầu:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Lưu bản thuyết trình ở định dạng Office Open XML Strict**

Để tạo một tệp PPTX tuân thủ hồ sơ Strict của Office Open XML, tạo một thể hiện [PptxOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/) và gọi [PptxOptions::set_Conformance](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/set_conformance/) với `Conformance::Iso29500_2008_Strict`. Sau đó truyền các tùy chọn này cho phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Lưu bản thuyết trình ở định dạng Office Open XML ở chế độ Zip64**

Một kho ZIP chuẩn giới hạn kích thước nén và giải nén của mỗi mục, tổng kích thước kho và số mục. Vì tệp PPTX là một kho ZIP, một bản thuyết trình rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số mục áp dụng.

Sử dụng [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) để kiểm soát việc Aspose.Slides có ghi phần mở rộng ZIP64 hay không:

- `IfNecessary` chỉ sử dụng ZIP64 khi bản thuyết trình vượt quá giới hạn ZIP chuẩn. Đây là chế độ mặc định.
- `Never` tắt các phần mở rộng ZIP64.
- `Always` luôn ghi các phần mở rộng ZIP64.

Ví dụ sau luôn bật các phần mở rộng ZIP64 cho bản thuyết trình đầu ra:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Nếu `Zip64Mode` được đặt thành `Never` và bản thuyết trình không thể vừa trong giới hạn ZIP chuẩn, thao tác lưu sẽ ném ra một [PptxException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu bản thuyết trình ở định dạng Office Open XML với mức nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách gọi [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). Enum [CompressionLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/compressionlevel/) cung cấp các giá trị sau:

- `None` lưu dữ liệu mà không nén.
- `Level1` cung cấp mức nén nhanh nhất và kích thước nén lớn nhất.
- `Level2` đến `Level5` dần dần ưu tiên kết quả nhỏ hơn hơn tốc độ lưu.
- `Level6` cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- `Level7` và `Level8` tiếp tục ưu tiên kết quả nhỏ hơn hơn tốc độ lưu.
- `Level9` cung cấp mức nén mạnh nhất và cần thời gian xử lý nhiều nhất.

Ví dụ sau lưu một bản thuyết trình mà không nén:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Ví dụ sau sử dụng mức nén tối đa:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Lưu bản thuyết trình mà không làm mới thumbnail**

Khi một bản thuyết trình được lưu dưới dạng PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) điều khiển thumbnail của tài liệu:

- `true` tạo lại thumbnail trong quá trình lưu. Đây là giá trị mặc định.
- `false` giữ nguyên thumbnail hiện có. Nếu bản thuyết trình không có thumbnail, Aspose.Slides sẽ không tạo.

Ví dụ sau lưu một bản thuyết trình mà không làm mới thumbnail:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Vô hiệu hoá việc làm mới thumbnail có thể giảm thời gian cần thiết để lưu tệp PPTX.
{{% /alert %}}

## **Cập nhật tiến trình lưu bằng phần trăm**

Để giám sát một thao tác lưu, triển khai giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprogresscallback/) và truyền triển khai đó cho [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides sau đó sẽ gọi [IProgressCallback::Reporting](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprogresscallback/reporting/) với các giá trị tiến độ trong quá trình xuất.

Ví dụ sau báo cáo tiến độ xuất PDF ra console:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bản thuyết trình dưới dạng các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Aspose.Slides có hỗ trợ lưu tăng dần hay “lưu nhanh”?**

Không. Mỗi thao tác lưu ghi toàn bộ tệp đầu ra thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một đối tượng Presentation không?**

Không. Một đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) [không an toàn với đa luồng](/slides/vi/cpp/multithreading/). Chỉ truy cập và lưu mỗi đối tượng từ một luồng tại một thời điểm.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi tôi lưu một bản thuyết trình?**

[Hyperlinks](/slides/vi/cpp/manage-hyperlinks/) vẫn còn trong bản thuyết trình. Aspose.Slides không sao chép các tệp liên kết bên ngoài, vì vậy bản thuyết trình đã lưu vẫn phải có khả năng truy cập đến vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [thuộc tính tài liệu](/slides/vi/cpp/presentation-properties/) phù hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.