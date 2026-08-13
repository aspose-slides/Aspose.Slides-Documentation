---
title: Nhập Bản Thuyết Trình từ PDF hoặc HTML trong C++
linktitle: Nhập Bản Thuyết Trình
type: docs
weight: 60
url: /vi/cpp/import-presentation/
keywords:
- nhập bản thuyết trình
- nhập slide
- nhập PDF
- nhập HTML
- PDF sang bản thuyết trình
- PDF sang PPT
- PDF sang PPTX
- PDF sang ODP
- HTML sang bản thuyết trình
- HTML sang PPT
- HTML sang PPTX
- HTML sang ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Nhập tài liệu PDF và HTML một cách dễ dàng vào các bản thuyết trình PowerPoint và OpenDocument trong C++ với Aspose.Slides để xử lý slide hiệu suất cao và liền mạch."
---
## **Giới thiệu**

Sử dụng [**Aspose.Slides for C++**](https://products.aspose.com/slides/vi/cpp/), bạn có thể nhập các bản thuyết trình từ các tệp ở định dạng khác. Aspose.Slides cung cấp lớp [SlideCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.slide_collection) để cho phép bạn nhập các bản thuyết trình từ PDF, tài liệu HTML, v.v.

## **Nhập PowerPoint từ PDF**

Trong trường hợp này, bạn sẽ chuyển đổi một tệp PDF sang bản thuyết trình PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Tạo một đối tượng của lớp presentation. 
2. Gọi phương thức [AddFromPdf()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) và truyền tệp PDF. 
3. Sử dụng phương thức [Save()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) để lưu tệp ở định dạng PowerPoint.

Đoạn mã C++ này minh họa quá trình chuyển đổi PDF sang PowerPoint:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
Bạn có thể muốn kiểm tra ứng dụng web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) vì nó là một triển khai thực tế của quy trình được mô tả ở đây. 
{{% /alert %}} 

## **Nhập PowerPoint từ HTML**

Trong trường hợp này, bạn sẽ chuyển đổi một tài liệu HTML sang bản thuyết trình PowerPoint.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/) . 
2. Gọi phương thức [AddFromHtml()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) và truyền tệp HTML. 
3. Sử dụng phương thức [Save()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) để lưu tệp ở định dạng PowerPoint.

Đoạn mã C++ này minh họa quá trình chuyển đổi HTML sang PowerPoint:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Bạn cũng có thể sử dụng Aspose.Slides để chuyển đổi HTML sang các định dạng tệp phổ biến khác: 

* [HTML sang hình ảnh](https://products.aspose.com/slides/vi/cpp/conversion/html-to-image/)
* [HTML sang JPG](https://products.aspose.com/slides/vi/cpp/conversion/html-to-jpg/)
* [HTML sang XML](https://products.aspose.com/slides/vi/cpp/conversion/html-to-xml/)
* [HTML sang TIFF](https://products.aspose.com/slides/vi/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **Câu hỏi thường gặp**

### Các bảng có được giữ nguyên khi nhập PDF không, và có thể cải thiện việc phát hiện chúng không?

Các bảng có thể được phát hiện trong quá trình nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/pdfimportoptions/) bao gồm phương thức [set_DetectTables](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của tệp PDF.