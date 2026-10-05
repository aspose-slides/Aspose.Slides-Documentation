---
title: Chuyển đổi PPT và PPTX sang PDF trong C++ [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/cpp/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- PowerPoint sang PDF
- bản trình bày sang PDF
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
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong C++ bằng Aspose.Slides, kèm các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Việc chuyển đổi các bản trình bày PowerPoint (PPT, PPTX, ODP, …) sang định dạng PDF trong C++ mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cũng như định dạng của bản trình bày. Hướng dẫn này minh họa cách chuyển đổi bản trình bày sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình bày ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình bày sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và sau đó lưu bản trình bày dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi bản trình bày sang PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình bày sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng một giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình bày sang PDF
* Các slide cụ thể từ một bản trình bày sang PDF

Aspose.Slides xuất bản trình bày ra PDF, đảm bảo các tệp PDF tạo ra gần giống với bản trình bày gốc. Các thành phần và thuộc tính được render chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn PowerPoint‑to‑PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình bày được cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Ví dụ sau tải một bản trình bày và lưu tất cả các slide có thể hiển thị sang PDF bằng các cài đặt xuất mặc định.

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

Aspose cung cấp một công cụ chuyển đổi trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) minh họa quy trình chuyển đổi bản trình bày sang PDF. Bạn có thể chạy thử công cụ này để xem thực tế quy trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách thực hiện quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với Các tùy chọn Tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa thiết lập chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và hơn thế nữa.

Ví dụ sau xuất một bản trình bày sang PDF 1.5 với chất lượng JPEG đặt ở 90, độ phân giải hình ảnh 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

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

### **Bảo tồn Các tệp OLE Nhúng làm Tệp Đính Kèm PDF**

Nếu một bản trình bày chứa một workbook Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của workbook đồng thời xem các slide. Gọi [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) với `true` để bảo tồn các tệp OLE nhúng làm tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được render trên trang PDF, nhưng tệp nhúng không được bao gồm làm tệp đính kèm. Đặt tùy chọn thành `true` sẽ thêm dữ liệu tệp vào. Bản xem trước vẫn là một hình ảnh đại diện; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình bày đã chứa workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

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
2. Mở bảng **Attachments** của trình xem và tìm workbook nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF riêng biệt với tệp đính kèm.

{{% alert color="info" title="Note" %}}

Tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.

{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Các slide Ẩn**

Nếu một bản trình bày chứa các slide ẩn, bạn có thể sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn làm trang trong PDF kết quả.

Ví dụ sau xuất một bản trình bày sang PDF, bao gồm bất kỳ slide ẩn nào.

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

Ví dụ sau xuất một bản trình bày sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

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

Aspose.Slides cung cấp phương thức [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình bày sang PDF.

Ví dụ sau xuất một bản trình bày sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất.

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

Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/cpp/font-substitution/).

{{% /alert %}} 

## **Chuyển Đổi Các Slide Được Chọn Từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình bày sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình bày đầu vào phải chứa ít nhất ba slide.

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

Ví dụ sau sao chép slide đầu tiên từ một bản trình bày vào một bản trình bày mới với kích thước slide 612 × 792 điểm (8.5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn lẻ sang PDF.

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

Ví dụ sau xuất một bản trình bày sang PDF, đặt ghi chú người thuyết trình của mỗi slide dưới slide. Sử dụng một bản trình bày có ghi chú người thuyết trình để xem kết quả.

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

Aspose.Slides cho phép bạn thực hiện quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã C++ này minh họa quy trình chuyển đổi PowerPoint‑to‑PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung độc lập và có thể được đánh dấu là artifact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu Hỏi Thường Gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi một cách lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để đặt mật khẩu và định nghĩa các quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có giữ lại chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương thức như [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) và [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh trong PDF của bạn có chất lượng cao.

**Aspose.Slides hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu về truy cập và lưu trữ.

## **Tài Nguyên Bổ Sung**

- [Aspose.Slides for C++ Documentation](/slides/vi/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)