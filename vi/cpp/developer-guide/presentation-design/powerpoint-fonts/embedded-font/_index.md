---
title: Nhúng Phông chữ trong Bản trình chiếu bằng C++
linktitle: Nhúng Phông chữ
type: docs
weight: 40
url: /vi/cpp/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- việc nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Nhúng phông chữ TrueType trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++, đảm bảo hiển thị chính xác trên mọi nền tảng."
---
## **Giới thiệu**

**Phông chữ nhúng trong PowerPoint** giúp đảm bảo rằng bản trình chiếu của bạn giữ nguyên giao diện dự định khi được mở trên bất kỳ hệ thống hay thiết bị nào. Điều này đặc biệt quan trọng khi bạn sử dụng phông chữ tùy chỉnh, của bên thứ ba hoặc không chuẩn cho mục đích thương hiệu hoặc sáng tạo. Nếu không nhúng phông chữ, văn bản có thể bị thay thế, bố cục có thể bị phá vỡ và các ký tự có thể hiển thị dưới dạng biểu tượng hoặc hình chữ nhật không đọc được, làm suy giảm thiết kế chung.

Aspose.Slides for C++ cung cấp một bộ API mạnh mẽ để quản lý phông chữ nhúng một cách lập trình. Bạn có thể sử dụng lớp [FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/) và [FontData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontdata/) để kiểm tra, thêm hoặc xóa phông chữ nhúng trong các tệp bản trình chiếu của mình. Ngoài ra, lớp [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) cho phép bạn tối ưu kích thước tệp bằng cách nén dữ liệu phông chữ mà không ảnh hưởng đến chất lượng hoặc giao diện.

Những công cụ này cung cấp cho bạn kiểm soát hoàn toàn việc nhúng phông chữ, giúp duy trì tính nhất quán về kiểu chữ trên các nền tảng trong khi giảm kích thước tệp khi cần thiết.

## **Lấy phông chữ nhúng từ bản trình chiếu**

Aspose.Slides for C++ cung cấp phương thức `GetEmbeddedFonts` thông qua lớp [FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/), cho phép bạn truy xuất danh sách các phông chữ đã được nhúng trong một bản trình chiếu PowerPoint. Điều này có thể hữu ích cho việc kiểm tra sử dụng phông chữ, đảm bảo tuân thủ các hướng dẫn thương hiệu, hoặc xác minh rằng tất cả các phông chữ cần thiết đã được bao gồm đúng cách trước khi chia sẻ tệp.

Đoạn mã C++ sau minh họa cách lấy phông chữ nhúng từ một tệp bản trình chiếu:

```cpp
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Lấy tất cả phông chữ đã nhúng.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// In tên của các phông chữ đã nhúng.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Thêm phông chữ nhúng vào bản trình chiếu**

Aspose.Slides for C++ cho phép bạn nhúng phông chữ vào một bản trình chiếu PowerPoint bằng phương thức [AddEmbeddedFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/addembeddedfont/), với hai overload để sử dụng linh hoạt. Bạn có thể kiểm soát mức độ nhúng phông chữ bằng cách sử dụng enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/embedfontcharacters/) — ví dụ, chỉ nhúng các ký tự đã được sử dụng hoặc toàn bộ bộ phông chữ. Tính năng này đặc biệt hữu ích khi chuẩn bị bản trình chiếu để chia sẻ hoặc phân phối, đảm bảo các phông chữ tùy chỉnh hoặc không chuẩn hiển thị đúng trên mọi hệ thống, ngay cả khi các phông chữ đó không được cài đặt.

Đoạn mã C++ dưới đây kiểm tra tất cả các phông chữ được sử dụng trong một bản trình chiếu và nhúng bất kỳ phông chữ nào chưa được nhúng trước đó.

```cpp
// Tải tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Kiểm tra xem phông chữ đã được nhúng chưa.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Nhúng phông chữ vào bản trình chiếu.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Lưu bản trình chiếu vào đĩa.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Xóa phông chữ nhúng khỏi bản trình chiếu**

Aspose.Slides for C++ cung cấp phương thức `RemoveEmbeddedFont` thông qua lớp [FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/), cho phép bạn xóa các phông chữ cụ thể đã được nhúng trong một bản trình chiếu PowerPoint. Điều này có thể giúp giảm kích thước tệp tổng thể, đặc biệt nếu các phông chữ nhúng không còn được sử dụng hoặc không cần thiết. Việc xóa các phông chữ không dùng còn có thể cải thiện hiệu năng và đảm bảo rằng bản trình chiếu chỉ bao gồm các tài nguyên cần thiết.

Đoạn mã C++ sau minh họa cách xóa một phông chữ nhúng khỏi bản trình chiếu:

```cpp
auto fontName = u"Calibri";

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Lấy tất cả các phông chữ đã nhúng.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Xóa phông chữ đã nhúng.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Nén phông chữ nhúng**

Aspose.Slides for C++ cung cấp phương thức `CompressEmbeddedFonts` thông qua lớp [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/), cho phép bạn giảm kích thước tệp tổng thể của bản trình chiếu bằng cách tối ưu dữ liệu phông chữ đã nhúng. Điều này đặc biệt hữu ích khi bản trình chiếu của bạn chứa các phông chữ lớn hoặc nhiều phông chữ, và bạn muốn giữ tệp nhẹ để chia sẻ, lưu trữ hoặc sử dụng trực tuyến — mà không làm suy giảm chất lượng hình ảnh của nội dung.

Đoạn mã C++ dưới đây minh họa cách nén phông chữ nhúng trong một bản trình chiếu PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết rằng một phông chữ cụ thể trong bản trình chiếu vẫn sẽ bị thay thế khi render dù đã nhúng?**

Kiểm tra [thông tin thay thế](/slides/vi/cpp/font-substitution/) trong trình quản lý phông chữ và [các quy tắc dự phòng/thay thế](/slides/vi/cpp/fallback-font/): nếu phông chữ không khả dụng hoặc bị hạn chế, một phông chữ dự phòng sẽ được sử dụng.

**Có nên nhúng các phông chữ “hệ thống” như Arial/Calibri không?**

Thông thường không — chúng hầu như luôn có sẵn. Nhưng đối với tính di động hoàn toàn trong môi trường “gọn” (Docker, máy chủ Linux không có phông chữ được cài sẵn), việc nhúng phông chữ hệ thống có thể loại bỏ rủi ro bị thay thế không mong muốn.