---
title: Chuỗi lựa chọn phông chữ trong Aspose.Slides cho .NET
linktitle: Lựa chọn phông chữ
type: docs
weight: 80
url: /vi/net/font-selection-sequence/
keywords:
- lựa chọn phông chữ
- thay thế phông chữ
- thay đổi phông chữ
- quy tắc thay thế
- phông chữ khả dụng
- phông chữ thiếu
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho .NET lựa chọn phông chữ, đảm bảo hiển thị PPT, PPTX và ODP sắc nét, nhất quán — cải thiện slide của bạn ngay."
---
## **Tổng quan**

Khi một bản trình bày được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides xem xét các phông chữ được nhúng và các phông chữ có sẵn cho ứng dụng. Nếu phông chữ yêu cầu không có, Aspose.Slides sẽ chọn một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.

Các phông chữ khả dụng có thể bao gồm phông chữ hệ thống, phông chữ được tải bởi ứng dụng và phông chữ được nhúng trong bản trình bày. Đối với một phông chữ nhúng và đã đăng ký phù hợp, tùy chọn .NET 26.11 được mô tả bên dưới sẽ kiểm soát ưu tiên. Các quy tắc thay thế phông chữ được định nghĩa thông qua [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) là một cơ chế riêng.

Bạn cũng có thể thêm phông chữ tại thời điểm chạy của ứng dụng, sử dụng phông chữ nhúng từ bản trình bày, hoặc tải phông chữ bên ngoài cho các tài liệu xuất như tệp PDF.

## **Lựa chọn Phông chữ**

Văn bản có thể tham chiếu đến một phông chữ chủ đề, chẳng hạn `+mn-lt`, thay vì một tên họ phông chữ cụ thể. Xem [Resolve Theme Font References](/slides/vi/net/presentation-theme/#resolve-theme-font-references) để lấy họ phông chữ được chỉ định bởi chủ đề áp dụng. Việc giải quyết tham chiếu này là riêng biệt so với việc kiểm tra tính khả dụng của phông chữ và áp dụng thay thế thời gian hiển thị hoặc dự phòng glyph; nó không xác định tệp phông chữ cuối cùng được sử dụng để hiển thị văn bản.

Khi hiển thị các slide hoặc chuyển đổi bản trình bày, kiểm tra xem các phông chữ yêu cầu đã được nhúng hoặc khả dụng từ các nguồn đã đăng ký chưa. Các phông chữ thiếu có thể yêu cầu thay thế hoặc thay thế phụ; xem [**Thay thế phông chữ**](/slides/vi/net/font-replacement/) và [**Thay thế phông chữ**](/slides/vi/net/font-substitution/).

Khi điều tra quá trình lựa chọn phông chữ:

1. Giải quyết họ và kiểu phông chữ yêu cầu, bao gồm bất kỳ tham chiếu chủ đề nào.
2. Kiểm tra phông chữ nhúng và các nguồn đã đăng ký, bao gồm phông chữ hệ thống và phông chữ được tải bởi ứng dụng. Sử dụng tùy chọn dưới đây khi phiên bản nhúng và đã đăng ký trùng khớp cạnh tranh.
3. Xem lại [các quy tắc thay thế phông chữ](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) và dự phòng glyph nếu phông chữ hoặc ký tự yêu cầu không có.

Aspose.Slides cho phép bạn thêm phông chữ vào thời điểm chạy của ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](/slides/vi/net/custom-font/).

Khi các phông chữ bổ sung được đặt trong một bản trình bày, chúng được gọi là [**Phông chữ nhúng**](/slides/vi/net/embedded-font/).

Aspose.Slides cho phép bạn thêm phông chữ chỉ được áp dụng cho *các tài liệu xuất*. Ví dụ, nếu một bản trình bày mà bạn muốn chuyển đổi sang PDF chứa các phông chữ thiếu trên hệ thống và các phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **external fonts**. 

{{% alert title="Note" color="info" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **Ưu tiên Phông chữ Đã Đăng ký hơn Phông chữ Nhúng**

Bắt đầu với .NET 26.11, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) cho phép một phông chữ đã đăng ký phù hợp được ưu tiên hơn phông chữ nhúng trong quá trình xuất. Mặc định là `false`. Việc khớp sử dụng tên và kiểu phông chữ; một họ khác không phải là một sự thay thế phù hợp. Các phông chữ đã đăng ký có thể đến từ hệ thống hoặc [các nguồn phông chữ được tải rõ ràng](/slides/vi/net/custom-font/).

Ví dụ sau sử dụng gói **Aspose.Slides.NET6.CrossPlatform 26.11** trên .NET 8. Thực hiện theo [hướng dẫn cài đặt](/slides/vi/net/installation/) cho môi trường của bạn. Cung cấp `embedded-fonts.pptx` có phông chữ nhúng và `preferred.ttf` có cùng tên họ và kiểu. Hai tệp phông chữ nên khác nhau rõ rệt nếu bạn muốn so sánh kết quả.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Cài đặt này thay đổi thứ tự ưu tiên phông chữ trong quá trình xuất; nó không đổi tên phông chữ của văn bản, không xóa dữ liệu phông chữ nhúng hoặc nhúng lại tệp đã đăng ký. Đây là cài đặt thời gian chạy: đặt lại sau khi mở lại bản trình bày. Nếu không có phông chữ đã đăng ký phù hợp, việc bật tùy chọn không cung cấp một phông chữ; hãy xác minh phông chữ và bố cục kết quả trong môi trường đích của bạn.

Đầu ra PNG và PDF với các phông chữ thường được tải rõ ràng đã được kiểm tra cho cấu hình trên. Kiểm tra các tệp phông chữ, kiểu, bản dựng SDK và định dạng đầu ra của bạn trước khi phụ thuộc vào kết quả giống hệt. Các chỉ số phông chữ có thể thay đổi ngắt dòng và vị trí. Sử dụng [font replacement](/slides/vi/net/font-replacement/) hoặc [substitution](/slides/vi/net/font-substitution/) khi bạn cần một họ khác, và [embedded-font operations](/slides/vi/net/embedded-font/) khi bạn cần thay đổi các phông chữ lưu trong bản trình bày.

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xác định những phông chữ thực sự được sử dụng trong một bản trình bày trước khi chuyển đổi?**

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng thông qua [trình quản lý phông chữ](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), vì vậy bạn có thể quyết định có nên [embed](/slides/vi/net/embedded-font/), [replace](/slides/vi/net/font-replacement/), hoặc thêm [các nguồn phông chữ bên ngoài](/slides/vi/net/custom-font/). Điều này giúp ngăn ngừa các sự thay thế không mong muốn trong quá trình hiển thị và xuất.

**Tôi có thể thêm các thư mục phông chữ bổ sung mà không cài đặt chúng trên hệ điều hành không?**

Có. Bạn có thể đăng ký [các nguồn phông chữ bên ngoài](/slides/vi/net/custom-font/) như thư mục hoặc luồng bộ nhớ trong để hiển thị và xuất. Điều này loại bỏ phụ thuộc vào phông chữ hệ thống và giữ cho bố cục dự đoán được.

**Làm sao tôi ngăn được việc tự động dự phòng sang một phông chữ không phù hợp khi một glyph bị thiếu?**

Định nghĩa rõ ràng [font replacement](/slides/vi/net/font-replacement/) và [các quy tắc dự phòng](/slides/vi/net/fallback-font/) trước. Bằng cách phân tích các phông chữ đã sử dụng và đặt ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán về kiểu chữ và tránh các kết quả không mong muốn.