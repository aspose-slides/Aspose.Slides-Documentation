---
title: Chuyển đổi PPT và PPTX sang PDF trong C++ [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/cpp/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- PowerPoint sang PDF
- bản thuyết trình sang PDF
- PPT sang PDF
- chuyển đổi PPT sang PDF
- PPTX sang PDF
- chuyển đổi PPTX sang PDF
- lưu PowerPoint dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX thành các tệp PDF chất lượng cao, có thể tìm kiếm trong C++ bằng Aspose.Slides, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản thuyết trình PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C++ mang lại một số lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bản thuyết trình sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản thuyết trình sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và sau đó lưu bản thuyết trình dưới dạng PDF bằng phương thức `Save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) cung cấp phương thức `Save` thường được dùng để chuyển đổi bản thuyết trình sang PDF.

{{%  alert title="NOTE" color="warning" %}} 

Aspose.Slides for C++ chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản thuyết trình sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản thuyết trình sang PDF
* Các slide cụ thể từ bản thuyết trình sang PDF

Aspose.Slides xuất bản thuyết trình sang PDF, đảm bảo các tệp PDF kết quả khớp chặt chẽ với bản thuyết trình gốc. Các yếu tố và thuộc tính được render chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn PowerPoint‑to‑PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản thuyết trình đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

Đoạn mã C++ dưới đây cho thấy cách chuyển đổi một bản thuyết trình (PPT, PPTX, ODP, v.v.) sang PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Lưu bản thuyết trình dưới dạng PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert color="info" %}} 

Aspose cung cấp một công cụ trực tuyến miễn phí **PowerPoint to PDF converter**(https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) cho phép bạn thử nghiệm quy trình chuyển đổi bản thuyết trình sang PDF. Bạn có thể chạy thử công cụ này để xem thực tế cách thực hiện quy trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/)—cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu, hoặc xác định cách thức quá trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Các tùy chọn tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa cài đặt chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bản thuyết trình PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Đặt chất lượng cho ảnh JPG.
pdfOptions->set_JpegQuality(90);

// Đặt DPI cho ảnh.
pdfOptions->set_SufficientResolution(300);

// Đặt hành vi cho metafile.
pdfOptions->set_SaveMetafilesAsPng(true);

// Đặt mức nén văn bản cho nội dung văn bản.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Xác định chế độ tuân thủ PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Lưu bản thuyết trình dưới dạng tài liệu PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Chuyển đổi PowerPoint sang PDF với Các slide ẩn**

Nếu bản thuyết trình chứa các slide ẩn, bạn có thể sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) của lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Đoạn mã C++ dưới đây cho thấy cách chuyển đổi một bản thuyết trình PowerPoint sang PDF với các slide ẩn được bao gồm:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Khởi tạo lớp PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Thêm các slide ẩn.
pdfOptions->set_ShowHiddenSlides(true);

// Lưu bản thuyết trình dưới dạng PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Chuyển đổi PowerPoint sang PDF được bảo mật bằng mật khẩu**

Đoạn mã C++ dưới đây minh họa cách chuyển đổi một bản thuyết trình PowerPoint thành PDF được bảo mật bằng mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Khởi tạo lớp PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Đặt mật khẩu PDF và các quyền truy cập.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Lưu bản thuyết trình dưới dạng PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [set_WarningCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/set_warningcallback/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản thuyết trình sang PDF.

Đoạn mã C++ dưới đây cho thấy cách phát hiện các thay thế phông chữ:

```c++
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

// Triển khai callback cảnh báo.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Đặt callback cảnh báo trong tùy chọn PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Lưu bản thuyết trình dưới dạng PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info" %}} 

Để biết thêm thông tin về việc nhận các callback cảnh báo khi có thay thế phông chữ trong quá trình render, xem mục [Getting Warning Callbacks for Fonts Substitution](/slides/vi/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm chi tiết về thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/cpp/font-substitution/).

{{% /alert %}} 

## **Chuyển đổi các Slide đã chọn từ PowerPoint sang PDF**

Đoạn mã C++ dưới đây minh họa cách chỉ chuyển đổi các slide cụ thể từ một bản thuyết trình PowerPoint sang PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Đặt mảng số slide.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Lưu bản thuyết trình dưới dạng PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide tùy chỉnh**

Đoạn mã C++ dưới đây minh họa cách chuyển đổi một bản thuyết trình PowerPoint sang PDF với kích thước slide được chỉ định:

```C++
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

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Tạo một bản thuyết trình mới với kích thước slide đã điều chỉnh.
auto resizedPresentation = MakeObject<Presentation>();

// Đặt kích thước slide tùy chỉnh.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Sao chép slide đầu tiên từ bản thuyết trình gốc.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Lưu bản thuyết trình đã điều chỉnh kích thước thành PDF có ghi chú.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ xem Ghi chú Slide**

Đoạn mã C++ dưới đây minh họa cách chuyển đổi một bản thuyết trình PowerPoint sang PDF bao gồm phần ghi chú:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Cấu hình các tùy chọn PDF với bố cục ghi chú.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Lưu bản thuyết trình thành PDF có ghi chú.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn thực hiện quy trình chuyển đổi tuân thủ các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã C++ dưới đây minh họa quy trình chuyển đổi PowerPoint‑to‑PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```C++
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF to SVG](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất ra PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là nhiễu; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

### Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng mã.

### Có thể bảo mật PDF đã chuyển đổi bằng mật khẩu không?

Chắc chắn rồi. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

### Làm sao để bao gồm các slide ẩn trong PDF?

Sử dụng phương thức `set_ShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

### Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương thức như `set_JpegQuality` và `set_SufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh trong PDF có độ phân giải cao.

### Aspose.Slides có hỗ trợ các tiêu chuẩn PDF/A không?

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, giúp tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ lâu dài.

## **Tài nguyên bổ sung**

- [Aspose.Slides for C++ Documentation](/slides/vi/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/vi/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/vi/conversion)