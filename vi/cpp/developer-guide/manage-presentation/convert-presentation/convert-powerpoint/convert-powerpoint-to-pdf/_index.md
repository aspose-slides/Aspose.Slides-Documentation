---
title: "Chuyển đổi PPT và PPTX sang PDF trong C++ [Bao gồm các tính năng nâng cao]"
linktitle: "PowerPoint sang PDF"
type: docs
weight: 40
url: /vi/cpp/convert-powerpoint-to-pdf/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bản thuyết trình"
- "PowerPoint sang PDF"
- "bản thuyết trình sang PDF"
- "PPT sang PDF"
- "chuyển đổi PPT sang PDF"
- "PPTX sang PDF"
- "chuyển đổi PPTX sang PDF"
- "lưu PowerPoint dưới dạng PDF"
- "lưu PPT dưới dạng PDF"
- "lưu PPTX dưới dạng PDF"
- "xuất PPT sang PDF"
- "xuất PPTX sang PDF"
- "tệp đính kèm"
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong C++ bằng Aspose.Slides, kèm theo ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản thuyết trình PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C++ mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cũng như định dạng của bản thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bản thuyết trình sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn những slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ vào tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản thuyết trình sang PDF, truyền tên tệp vào lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) rồi lưu bản thuyết trình dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) thường được dùng để chuyển đổi bản thuyết trình sang PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản thuyết trình sang PDF, Aspose.Slides điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản thuyết trình sang PDF
* Các slide cụ thể từ một bản thuyết trình sang PDF

Aspose.Slides xuất bản thuyết trình sang PDF, đảm bảo các PDF kết quả gần như khớp với bản thuyết trình gốc. Các yếu tố và thuộc tính được render một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Điểm đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quy trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản thuyết trình đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Ví dụ sau tải một bản thuyết trình và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

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

Aspose cung cấp một bộ chuyển đổi [**bộ chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) trực tuyến miễn phí, minh họa quy trình chuyển đổi bản thuyết trình sang PDF. Bạn có thể thử nghiệm với bộ chuyển đổi này để xem thực tế quá trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—cho phép bạn tùy chỉnh PDF đầu ra, khóa PDF bằng mật khẩu hoặc chỉ định cách quá trình chuyển đổi sẽ tiến hành.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Bằng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng ưa thích cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh và hơn thế nữa.

Ví dụ sau xuất một bản thuyết trình sang PDF 1.5 với chất lượng JPEG đặt ở 90, độ phân giải hình ảnh đặt ở 300 DPI, metafile được lưu dưới dạng PNG và nén văn bản Flate.

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

### **Bảo lưu các Tệp OLE Nhúng dưới dạng Tệp Đính Kèm PDF**

Nếu bản thuyết trình chứa một sổ làm việc Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của sổ làm việc cũng như xem các slide. Gọi [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) với `true` để bảo lưu các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được render trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn thành `true` sẽ thêm dữ liệu tệp. Bản xem trước vẫn là hình ảnh đại diện; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một bảng tính Excel tương tác trên trang PDF.

Ví dụ sau tải một bản thuyết trình đã chứa sổ làm việc Excel nhúng và xuất nó sang PDF với sổ làm việc được đính kèm.

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
2. Mở bảng **Attachments** của trình xem và tìm sổ làm việc đã nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF tách biệt khỏi tệp đính kèm.

{{% alert color="info" title="Note" %}}

Các tiêu chuẩn PDF/A áp đặt hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm sổ làm việc Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.

{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu bản thuyết trình chứa các slide ẩn, bạn có thể sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn thành các trang trong PDF kết quả.

Ví dụ sau xuất một bản thuyết trình sang PDF, bao gồm bất kỳ slide ẩn nào.

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

### **Chuyển đổi PowerPoint sang PDF Bảo Vệ Bằng Mật Khẩu**

Ví dụ sau xuất một bản thuyết trình sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

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

### **Phát Hiện Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản thuyết trình sang PDF.

Ví dụ sau xuất một bản thuyết trình sang PDF và in cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng được thay thế trong quá trình xuất.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
 <Warnings/ReturnAction.h>
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

Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/cpp/font-substitution/).

{{% /alert %}} 

### **Xử Lý Phông Chữ Không Có Kiểu Đậm Riêng**

Một bản thuyết trình có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu đậm riêng. Văn bản vẫn có thể xuất hiện đậm thông qua việc làm đậm tổng hợp, làm dày các glyph thường một cách nhân tạo. Khi văn bản đó trông quá đậm hoặc không giống như mong muốn trong PDF, hãy thử gọi [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) với `true`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện hiển thị cho một số phông chữ. Giá trị mặc định là `false`.

Bản thuyết trình mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cho cùng một phông chữ, nhưng không có kiểu đậm riêng. Ví dụ sau tải bản thuyết trình, bật rasterization cho các kiểu phông chữ không hỗ trợ, và xuất nó sang PDF:

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

Các hình xem trước dưới đây cho thấy kết quả khi tắt và bật tùy chọn. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn bị tắt. Khi tùy chọn bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bản thuyết trình của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ biến văn bản đậm thành bitmap: không thể chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó xuất hiện mềm hơn ở mức phóng đại 800 %. Văn bản thường vẫn có thể tìm kiếm. Khi tùy chọn bị tắt, cả hai chuỗi đều vẫn là văn bản.

Tùy chọn này rasterizes văn bản được định dạng đậm khi phông chữ không có kiểu đậm riêng. [Font substitution](/slides/vi/cpp/font-substitution/) sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển Đổi Các Slide Đã Chọn từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản thuyết trình sang PDF. Các số slide trong mảng này được đánh số bắt đầu từ 1, và bản thuyết trình đầu vào phải chứa ít nhất ba slide.

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

## **Chuyển Đổi PowerPoint sang PDF với Kích Thước Slide Tùy Chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản thuyết trình vào một bản thuyết trình mới với kích thước slide 612 × 792 điểm (8.5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn sang PDF.

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

## **Chuyển Đổi PowerPoint sang PDF trong Chế Độ Xem Ghi Chú Slide**

Ví dụ sau xuất một bản thuyết trình sang PDF, đặt ghi chú người thuyết trình của mỗi slide dưới slide. Sử dụng một bản thuyết trình có ghi chú người thuyết trình để xem kết quả.

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

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ theo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã C++ sau minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF sang SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Note:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần đường riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu Hỏi Thường Gặp**

**Tôi có thể chuyển đổi hàng loạt nhiều tệp PowerPoint sang PDF không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương thức như [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) và [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng các yêu cầu về truy cập và lưu trữ.

## **Tài Nguyên Bổ Sung**

- [Aspose.Slides for C++ Documentation](/slides/vi/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)