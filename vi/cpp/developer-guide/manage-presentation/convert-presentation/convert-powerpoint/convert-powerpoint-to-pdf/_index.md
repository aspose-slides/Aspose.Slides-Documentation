---
title: "Chuyển đổi PPT và PPTX sang PDF trong C++ [Tính năng nâng cao được bao gồm]"
linktitle: "PowerPoint sang PDF"
type: docs
weight: 40
url: /vi/cpp/convert-powerpoint-to-pdf/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bản trình chiếu"
- "PowerPoint sang PDF"
- "bản trình chiếu sang PDF"
- "PPT sang PDF"
- "chuyển đổi PPT sang PDF"
- "PPTX sang PDF"
- "chuyển đổi PPTX sang PDF"
- "lưu PowerPoint dưới dạng PDF"
- "lưu PPT dưới dạng PDF"
- "lưu PPTX dưới dạng PDF"
- "xuất PPT sang PDF"
- "xuất PPTX sang PDF"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "C++"
- "Aspose.Slides"
description: "Chuyển đổi PowerPoint PPT/PPTX sang các tệp PDF chất lượng cao, có thể tìm kiếm trong C++ bằng Aspose.Slides, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C++ mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cùng định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện sự thay thế phông chữ, chọn slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức `Save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) cung cấp phương thức `Save` thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for C++ chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng “*Aspose.Slides*” và trường PDF Producer bằng giá trị dạng “*Aspose.Slides v XX.XX*”. **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất các bản trình chiếu sang PDF, đảm bảo các PDF kết quả gần giống với bản trình chiếu gốc. Các yếu tố và thuộc tính được render một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các ô văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Header và footer
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

```c++
// Tạo một đối tượng của lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Lưu bản trình chiếu dưới dạng PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
Aspose cung cấp một công cụ chuyển đổi PowerPoint sang PDF trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) cho thấy quá trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để xem thực tế quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/)—cho phép bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Tùy chọn Tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa cài đặt chất lượng ưa thích cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho ảnh và nhiều hơn nữa.

```c++
// Tạo một đối tượng của lớp PdfOptions.
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

// Tạo một đối tượng của lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Lưu bản trình chiếu dưới dạng tài liệu PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn dưới dạng các trang trong PDF kết quả.

```c++
// Tạo một đối tượng của lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Tạo một đối tượng của lớp PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Thêm các slide ẩn.
pdfOptions->set_ShowHiddenSlides(true);

// Lưu bản trình chiếu dưới dạng PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Chuyển đổi PowerPoint sang PDF có Bảo mật Mật khẩu**

Đoạn mã C++ này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF có bảo mật bằng mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/):

```c++
// Tạo một đối tượng của lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Tạo một đối tượng của lớp PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Đặt mật khẩu PDF và các quyền truy cập.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Lưu bản trình chiếu dưới dạng PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [set_WarningCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/set_warningcallback/) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Đoạn mã C++ này cho thấy cách phát hiện các trường hợp thay thế phông chữ:

```c++
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
    // Tạo một đối tượng của lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Đặt callback cảnh báo trong tùy chọn PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 
Để biết thêm thông tin về việc nhận các callback khi có thay thế phông chữ trong quá trình render, xem [Getting Warning Callbacks for Fonts Substitution](/slides/vi/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/cpp/font-substitution/).
{{% /alert %}} 

## **Chuyển đổi các Slide Được Chọn từ PowerPoint sang PDF**

Đoạn mã C++ này minh họa cách chuyển đổi chỉ các slide cụ thể từ một bản trình chiếu PowerPoint sang PDF:

```C++
// Tạo một đối tượng của lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Đặt mảng các số slide.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Lưu bản trình chiếu dưới dạng PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Đoạn mã C++ này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với kích thước slide được chỉ định:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ Slide Ghi chú**

Đoạn mã C++ này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF có bao gồm ghi chú:

```C++
// Tạo một đối tượng của lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Cấu hình các tùy chọn PDF với bố cục ghi chú.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Lưu bản trình chiếu thành PDF có ghi chú.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã C++ này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```C++
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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF sang SVG](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/vi/cpp/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần đường riêng lẻ không được giữ lại như nội dung riêng biệt và có thể được đánh dấu là hiện tượng phụ; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?**

Đúng, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quy trình chuyển đổi bằng lập trình.

**Có thể bảo mật bằng mật khẩu cho PDF đã chuyển đổi không?**

Chắc chắn. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức `set_ShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như `set_JpegQuality` và `set_SufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng các yêu cầu về khả năng truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho C++](/slides/vi/cpp/)
- [Tham chiếu API Aspose.Slides cho C++](https://reference.aspose.com/slides/vi/cpp/)
- [Bộ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)