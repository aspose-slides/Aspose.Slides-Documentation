---
title: "Truy xuất và Cập nhật Thông tin Bản trình chiếu trong C++"
linktitle: "Thông tin Bản trình chiếu"
type: docs
weight: 30
url: /vi/cpp/examine-presentation/
keywords:
- "định dạng bản trình chiếu"
- "thuộc tính bản trình chiếu"
- "thuộc tính tài liệu"
- "lấy thuộc tính"
- "đọc thuộc tính"
- "thay đổi thuộc tính"
- "sửa đổi thuộc tính"
- "cập nhật thuộc tính"
- "kiểm tra PPTX"
- "kiểm tra PPT"
- "kiểm tra ODP"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "C++"
- "Aspose.Slides"
description: "Khám phá slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng C++ để có cái nhìn nhanh hơn và kiểm toán nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình chiếu và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng trình chiếu hoàn chỉnh. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng một kho lưu trữ, hoặc kiểm tra các thuộc tính trước khi quyết định có nên tải và xử lý nội dung bản trình chiếu hay không.

Bài viết này minh họa cách kiểm tra nhẹ nhàng thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentationfactory/) và [IPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/), cũng như cách cập nhật có mục tiêu thông qua [IDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/).

## **Kiểm tra định dạng bản trình chiếu**

Nếu bạn đã có một bản trình chiếu đã được tải, xem [Determine the Original Presentation Format](/slides/vi/cpp/detect-presentation-source-format/) để phát hiện sau khi tải và các hạn chế của các luồng PPT, PPS và POT legacy.

Sử dụng [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) để kiểm tra tệp mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) . Phương thức [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/get_loadformat/) báo cáo định dạng đã phát hiện, chẳng hạn PPTX, PPT hoặc ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Xây dựng kho lưu trữ bản trình chiếu nhẹ**

Khi bạn xử lý nhiều tệp bản trình chiếu, bạn có thể cần một kho lưu trữ gọn nhẹ để xác thực, lập chỉ mục hoặc cho hệ thống quản lý tài liệu. Trong trường hợp này, sử dụng [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) để lấy một đối tượng [IPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/) , sau đó gọi [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) hoặc yêu cầu bạn phải duyệt toàn bộ mô hình đối tượng bản trình chiếu.

Các thuộc tính mở rộng được công bố bởi [IDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/) cung cấp các giá trị kho lưu trữ sau:

| Phương thức | Giá trị kho |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_slides/) | Tổng số slide. |
| [get_HiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Số slide ẩn. |
| [get_Notes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_notes/) | Số slide chứa ghi chú. |
| [get_Paragraphs](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Tổng số đoạn văn, nếu có. |
| [get_Words](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_words/) | Tổng số từ. |
| [get_MultimediaClips](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Tổng số đoạn âm thanh và video. |

Ví dụ sau đọc các giá trị này mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và in ra một kho lưu trữ gọn nhẹ. Nó cũng kết hợp [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_headingpairs/) với [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) để hiển thị các nhóm nội dung như phông chữ, chủ đề và tiêu đề slide.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Mỗi [IHeadingPair](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iheadingpair/) cung cấp một tên nhóm qua [IHeadingPair::get_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iheadingpair/get_name/) và số mục trong nhóm qua [IHeadingPair::get_Count](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) trả về một mảng phẳng, có thứ tự, vì vậy hãy tiêu thụ số tiêu đề liên tiếp được chỉ định bởi mỗi cặp tiêu đề.

### **Siêu dữ liệu đã lưu và các hạn chế định dạng**

Các thuộc tính kho lưu trữ được trả về bởi [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) phản ánh siêu dữ liệu có sẵn trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình chiếu để tính lại các giá trị này cho lời gọi này. Các thuộc tính thiếu được biểu diễn bằng giá trị mặc định, và các giá trị đã lưu có thể đã lỗi thời nếu ứng dụng đã lưu tệp cuối cùng không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng cung cấp các thuộc tính tài liệu mở rộng cho số slide, ghi chú, slide ẩn, đoạn văn, từ và số đa phương tiện, cũng như cặp tiêu đề và tiêu đề phần. Tính sẵn có phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính không tồn tại hoặc không được nhà sản xuất tài liệu cập nhật, Aspose.Slides sẽ trả về giá trị đã lưu hoặc mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp các thống kê tài liệu chung, chẳng hạn số trang, đoạn văn và từ, nhưng các giá trị này không ánh xạ tới mọi thuộc tính mở rộng đặc thù của PowerPoint. Siêu dữ liệu cho slide ẩn, slide ghi chú, đa phương tiện, cặp tiêu đề và tiêu đề phần có thể không khả dụng, và các thuộc tính kho lưu trữ có thể trả về giá trị mặc định. Đừng coi một giá trị zero hoặc một mảng trống là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho các kho lưu trữ và kiểm tra sơ bộ. Tải bản trình chiếu và kiểm tra mô hình đối tượng trực tiếp khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình chiếu.

## **Cập nhật thuộc tính bản trình chiếu**

Các thuộc tính được trả về bởi [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) cũng có thể được thay đổi mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) . Áp dụng các thay đổi bằng [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), sau đó ghi bản trình chiếu đã liên kết bằng [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

![Thuộc tính tài liệu gốc của bản trình chiếu PowerPoint](input_properties.png)

Ví dụ sau thay đổi tiêu đề và thời gian lưu lần cuối và ghi kết quả vào một tệp mới:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

![Thuộc tính tài liệu đã thay đổi của bản trình chiếu PowerPoint](output_properties.png)

## **Liên kết hữu ích**

- [Bảo vệ bản trình chiếu bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/)
- [Bảo vệ bản trình chiếu khỏi ghi](/slides/vi/cpp/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào để kiểm tra xem phông chữ có được nhúng hay không và chúng là gì?**

Tải bản trình chiếu và sử dụng [Presentation::get_FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_fontsmanager/). Gọi [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) để lấy các phông chữ đã nhúng và [FontsManager::GetFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getfonts/) để lấy các phông chữ được sử dụng bởi bản trình chiếu. So sánh hai kết quả để tìm các phông chữ cần thiết cho việc render nhưng chưa được nhúng.

**Làm thế nào để nhanh chóng biết tệp có slide ẩn hay không và có bao nhiêu?**

Khi siêu dữ liệu tài liệu đã lưu đủ, đọc [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) qua [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) và [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Cách này phù hợp cho một kho lưu trữ nhẹ. Nếu bản trình chiếu đã được sửa đổi trong bộ nhớ, siêu dữ liệu đã lưu có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh giá trị thực tế, hãy duyệt qua [Presentation::get_Slides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slides/) và kiểm tra mỗi slide bằng phương thức [Slide::get_Hidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/get_hidden/) thay vì.

**Tôi có thể phát hiện xem kích thước và định hướng slide tùy chỉnh có được sử dụng không, và chúng có khác so với mặc định không?**

Có. Tải bản trình chiếu và đọc [Presentation::get_SlideSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slidesize/). Kiểm tra [ISlideSize::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidesize/get_size/), và [ISlideSize::get_Orientation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidesize/get_orientation/) để so sánh cài đặt hiện tại với preset và kích thước dự kiến.

**Có cách nhanh để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Xác định mỗi [Chart](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chart/) và kiểm tra [ChartData::get_DataSourceType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Đối với một workbook bên ngoài, đọc [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Loại nguồn dữ liệu và đường dẫn xác định một tham chiếu bên ngoài, nhưng để xác minh nguồn có tồn tại hay không cần kiểm tra tài nguyên riêng.

**Làm thế nào để đánh giá các slide 'nặng' có thể làm chậm quá trình render hoặc xuất PDF?**

Không có một thuộc tính phức tạp duy nhất. Duyệt [Presentation::get_Slides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slides/) và mỗi slide qua bộ sưu tập [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_shapes/). Sử dụng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, animation hoặc đa phương tiện làm tín hiệu sàng lọc, và đo một lần render hoặc export đại diện trước khi xác định slide là nút thắt hiệu suất thực sự.