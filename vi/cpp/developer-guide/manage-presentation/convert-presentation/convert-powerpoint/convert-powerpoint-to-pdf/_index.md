---
title: Chuyển đổi PPT và PPTX sang PDF trong C++ [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/cpp/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- PowerPoint sang PDF
- bản trình chiếu sang PDF
- PPT sang PDF
- chuyển đổi PPT sang PDF
- PPTX sang PDF
- chuyển đổi PPTX sang PDF
- lưu PowerPoint dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- tệp đính kèm
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có khả năng tìm kiếm trong C++ bằng Aspose.Slides, kèm các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C++ mang lại nhiều lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) thường được dùng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng “*Aspose.Slides*” và trường PDF Producer bằng một giá trị dạng “*Aspose.Slides v XX.XX*”. **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các tệp PDF kết quả khớp chặt chẽ với bản trình chiếu gốc. Các yếu tố và thuộc tính được render chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Gạch đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình chiếu đã cho sang PDF bằng các thiết lập tối ưu ở mức chất lượng tối đa.

Ví dụ dưới đây tải một bản trình chiếu và lưu tất cả các slide hiển thị dưới dạng PDF bằng các cài đặt xuất mặc định.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose cung cấp một công cụ trực tuyến miễn phí [**trình chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để thấy thực tế quy trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh — các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu hoặc chỉ định cách quy trình chuyển đổi nên tiến hành.

### **Chuyển đổi PowerPoint sang PDF với Các tùy chọn tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ dưới đây xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG được đặt là 90, độ phân giải hình ảnh là 300 DPI, metafile được lưu dưới dạng PNG và nén văn bản Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Tự động Chọn Nén Hình Ảnh**

Khi bản trình chiếu chứa nhiều ảnh chụp hoặc ảnh chụp màn hình, giảm kích thước PDF xuất ra có thể giúp việc gửi email hoặc tải xuống dễ dàng hơn. Gọi [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) với `true` để tự động chọn thuật toán nén phù hợp nhất cho mỗi hình ảnh trong quá trình xuất PDF.

Ví dụ dưới đây tải một bản trình chiếu hiện có, bật lựa chọn nén hình ảnh tự động và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác giữ nguyên giá trị mặc định.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Tùy chọn này chọn một thuật toán nén cho mỗi hình ảnh. Giảm chất lượng JPEG bằng [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) sẽ làm giảm chất lượng ảnh JPEG, trong khi giảm độ phân giải bằng [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) cho phép giảm độ phân giải của ảnh, từ đó giảm chi tiết. Việc bật lựa chọn nén tự động không tự động làm giảm các cài đặt này.

Lựa chọn thuật toán nén ảnh cần thời gian xử lý và bộ nhớ bổ sung. Việc giảm kích thước phụ thuộc vào hình ảnh trong bản trình chiếu và cài đặt xuất; không có mức giảm cố định cho mọi bản trình chiếu.

### **Bảo tồn Tệp OLE Nhúng dưới dạng Tệp Đính Kèm PDF**

Nếu bản trình chiếu chứa một sổ làm việc Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu sổ làm việc đồng thời xem các slide. Gọi [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) với `true` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn thành `true` sẽ bao gồm dữ liệu tệp. Hình xem trước vẫn chỉ là biểu diễn hình ảnh; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một bảng tính Excel tương tác trên trang PDF.

Ví dụ dưới đây tải một bản trình chiếu đã chứa sổ làm việc Excel nhúng và xuất nó sang PDF với sổ làm việc được đính kèm.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm tệp sổ làm việc đã nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Hình xem trước trên trang PDF tách biệt với tệp đính kèm.

{{% alert color="info" title="Note" %}}

Các tiêu chuẩn PDF/A đặt ra hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm sổ làm việc Excel. Đây là yêu cầu của các tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa việc xuất PDF/A.

{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Ví dụ dưới đây xuất một bản trình chiếu sang PDF, bao gồm mọi slide ẩn.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Chuyển đổi PowerPoint sang PDF có Bảo vệ Mật khẩu**

Ví dụ dưới đây xuất một bản trình chiếu sang PDF cần mật khẩu `password` để mở. Quyền truy cập cho phép in, bao gồm in chất lượng cao.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) cho phép bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Ví dụ dưới đây xuất một bản trình chiếu sang PDF và in cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Để biết thêm thông tin về việc thay thế phông chữ, tham khảo bài viết [Thay thế phông chữ](/slides/vi/cpp/font-substitution/).

{{% /alert %}} 

### **Xử lý Phông chữ Không Có Kiểu Bold Riêng**

Một bản trình chiếu có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu bold riêng. Văn bản vẫn có thể xuất hiện đậm thông qua việc làm synthetic bold, tức là làm dày các glyph thường. Khi văn bản này trông quá nặng hoặc khác với mong muốn trong PDF, hãy thử gọi [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) với `true`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện hiển thị cho một số phông chữ. Giá trị mặc định là `false`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một chứa văn bản thường và một chứa văn bản đậm áp dụng cùng một phông chữ không có kiểu bold riêng. Ví dụ dưới đây tải bản trình chiếu, bật rasterization cho các kiểu phông chữ không được hỗ trợ và xuất nó sang PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Các hình dưới đây hiển thị kết quả khi tắt và khi bật tùy chọn. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn bị tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. Hãy so sánh kết quả trước khi quyết định cài đặt cho bản trình chiếu của bạn.

| Tùy chọn bị tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF với raster hóa kiểu phông chữ không được hỗ trợ bị tắt](unsupported-bold-disabled.png) | ![PDF với raster hóa kiểu phông chữ không được hỗ trợ được bật](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ chuyển đổi văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản nếu không có OCR, và các cạnh của nó trông mềm hơn ở mức phóng to 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tùy chọn bị tắt, cả hai chuỗi vẫn là văn bản.

Tùy chọn này rasterize văn bản được định dạng là đậm khi phông chữ không có kiểu bold riêng. Thay thế phông chữ [Thay thế phông chữ](/slides/vi/cpp/font-substitution/) sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi Các Slide Được Chọn từ PowerPoint sang PDF**

Ví dụ dưới đây xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này được đánh số bắt đầu từ 1, và bản trình chiếu đầu vào phải có ít nhất ba slide.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Ví dụ dưới đây sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide 612 × 792 điểm (8.5 × 11 inch). Nó sẽ co giãn nội dung slide để vừa và xuất slide đơn này sang PDF.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Chuyển đổi PowerPoint sang PDF ở Chế độ Xem Ghi chú Slide**

Ví dụ dưới đây xuất một bản trình chiếu sang PDF, đặt ghi chú người thuyết trình của mỗi slide phía dưới slide. Sử dụng bản trình chiếu có ghi chú để xem kết quả.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã C++ dưới đây minh họa một quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác — [PDF sang SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — cũng được hỗ trợ.

{{% /alert %}}

> **Note:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung độc lập và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho cả hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng mã.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có giữ được chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương thức như [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) và [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh trong PDF có chất lượng cao.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu về truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho C++](/slides/vi/cpp/)
- [Tham chiếu API Aspose.Slides cho C++](https://reference.aspose.com/slides/cpp/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)