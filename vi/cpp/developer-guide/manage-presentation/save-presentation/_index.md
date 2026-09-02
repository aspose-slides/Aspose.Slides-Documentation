---
title: Lưu Bài Thuyết Trình trong C++
linktitle: Lưu Bài Thuyết Trình
type: docs
weight: 80
url: /vi/cpp/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài thuyết trình tới tệp
- bài thuyết trình tới stream
- kiểu xem được định nghĩa trước
- Định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- C++
- Aspose.Slides
description: "Khám phá cách lưu bài thuyết trình trong C++ bằng Aspose.Slides—xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in C++](/slides/vi/cpp/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) để mở một bài thuyết trình. Bài viết này giải thích cách tạo và lưu các bài thuyết trình. Lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa nội dung của một bài thuyết trình. Cho dù bạn đang tạo một bài thuyết trình mới từ đầu hay chỉnh sửa một bài đã tồn tại, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho C++, bạn có thể lưu thành **file** hoặc **stream**. Bài viết này giải thích các cách khác nhau để lưu một bài thuyết trình.

## **Lưu Bài Thuyết Trình vào Tập Tin**

Lưu một bài thuyết trình vào tập tin bằng cách gọi phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Truyền tên tập tin và định dạng lưu vào phương thức. Ví dụ sau cho thấy cách lưu một bài thuyết trình bằng Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
auto presentation = MakeObject<Presentation>();

// Thực hiện một số công việc ở đây...

// Lưu bài thuyết trình vào một tệp.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Lưu Bài Thuyết Trình vào Stream**

Bạn có thể lưu một bài thuyết trình vào stream bằng cách truyền một output stream vào phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Một bài thuyết trình có thể được ghi vào nhiều loại stream. Trong ví dụ dưới đây, chúng tôi tạo một bài thuyết trình mới và lưu nó vào một file stream.

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

// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Lưu bài thuyết trình vào stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Lưu Bài Thuyết Trình với Kiểu Xem Định Nghĩa Trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi mở bài thuyết trình đã tạo thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/). Sử dụng phương thức [set_LastView](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/set_lastview/) với một giá trị từ enumeration [ViewType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewtype/).

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

## **Lưu Bài Thuyết Trình ở Định Dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bài thuyết trình ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt `Conformance.Iso29500_2008_Strict`, tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bài thuyết trình và lưu nó ở định dạng Strict Office Open XML.

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

// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
auto presentation = MakeObject<Presentation>();

// Lưu bài thuyết trình ở định dạng Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML trong Chế Độ Zip64**

Một tệp Office Open XML là một archive ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của archive, đồng thời giới hạn archive tối đa 65 535 (2^16‑1) tệp. Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- `IfNecessary` chỉ sử dụng các phần mở rộng ZIP64 nếu bài thuyết trình vượt quá các giới hạn trên. Đây là chế độ mặc định.
- `Never` không bao giờ sử dụng các phần mở rộng ZIP64.
- `Always` luôn luôn sử dụng các phần mở rộng ZIP64.

The following code demonstrates how to save a presentation as a PPTX file with ZIP64 format extensions enabled:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với `Zip64Mode.Never`, một [PptxException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxexception/) sẽ được ném nếu bài thuyết trình không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML với Các Mức Nén**

Khi làm việc với các bài thuyết trình lớn, bạn có thể điều chỉnh mức nén để cân bằng kích thước tệp và thời gian xử lý. Tùy thuộc vào yêu cầu của bạn, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp phương thức [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/), cho phép bạn chỉ định mức nén được sử dụng khi lưu một bài thuyết trình ở định dạng Office Open XML.

Các mức nén sau đây khả dụng:

- **None**: Không áp dụng nén. Các tệp được lưu nguyên như ban đầu.
- **Level1:** Nén nhanh nhất với tỷ lệ nén thấp nhất.
- **Level2:** Nén nhanh hơn với tỷ lệ nén hơi tốt hơn **Level1**.
- **Level3:** Cung cấp mức nén tốt hơn **Level2** với ảnh hưởng vừa phải đến thời gian xử lý.
- **Level4:** Cung cấp mức nén tốt hơn **Level3**.
- **Level5:** Cung cấp mức nén cải thiện so với **Level4** với thời gian xử lý thêm.
- **Level6:** Nén tiêu chuẩn cung cấp cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- **Level7:** Cung cấp mức nén tốt hơn **Level6** nhưng xử lý chậm hơn.
- **Level8:** Cung cấp mức nén tốt hơn **Level7**.
- **Level9:** Nén tối đa. Tạo kích thước tệp nhỏ nhất nhưng tốn thời gian xử lý lâu nhất.

Ví dụ dưới đây minh họa cách lưu một bài thuyết trình dưới dạng tệp PPTX *không nén*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Ví dụ này cho thấy cách lưu một bài thuyết trình dưới dạng tệp PPTX với *nén tối đa*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Lưu Bài Thuyết Trình mà Không Làm Mới Hình Thu Nhỏ**

Phương thức [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) kiểm soát việc tạo hình thu nhỏ khi lưu một bài thuyết trình thành PPTX:

- Nếu được đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu được đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ lại. Nếu bài thuyết trình không có hình thu nhỏ, sẽ không tạo nào.

Trong mã dưới đây, bài thuyết trình được lưu thành PPTX mà không làm mới hình thu nhỏ của nó.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài thuyết trình ở định dạng PPTX.
{{% /alert %}}

## **Cập Nhật Tiến Trình Lưu theo Phần Trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprogresscallback/) được sử dụng thông qua phương thức `set_ProgressCallback` được công khai bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/). Gán một triển khai [IProgressCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprogresscallback/) bằng `set_ProgressCallback` để nhận các cập nhật tiến độ lưu dưới dạng phần trăm.

The following code snippets show how to use `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
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

// Lớp callback tiến độ được định nghĩa ở trên.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn chia một bài thuyết trình thành nhiều tệp bằng cách lưu các slide đã chọn thành các tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Có hỗ trợ “fast save” (lưu tăng dần) để chỉ ghi các thay đổi không?**

Không. Khi lưu, luôn tạo tệp đích đầy đủ mỗi lần; “fast save” tăng dần không được hỗ trợ.

**Có an toàn đa luồng khi lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/cpp/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp liên kết bên ngoài khi lưu?**

[Siêu liên kết](/slides/vi/cpp/manage-hyperlinks/) được giữ lại. Các tệp liên kết bên ngoài (ví dụ: video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/cpp/presentation-properties/) chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.