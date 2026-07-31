---
title: "Trình tự lựa chọn phông chữ trong Aspose.Slides cho C++"
linktitle: "Lựa chọn phông chữ"
type: docs
weight: 80
url: /vi/cpp/font-selection-sequence/
keywords:
- lựa chọn phông chữ
- thay thế phông chữ
- thay đổi phông chữ
- quy tắc thay thế
- phông chữ có sẵn
- phông chữ thiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho C++ chọn phông chữ, đảm bảo hiển thị PPT, PPTX và tệp ODP sắc nét, nhất quán — cải thiện slide của bạn ngay bây giờ."
---
## **Tổng quan**

Khi một bản trình chiếu được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình chiếu có sẵn trong hệ điều hành hay không. Nếu một phông chữ bắt buộc bị thiếu, Aspose.Slides sẽ chọn một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides đầu tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu tìm thấy phông chữ, nó sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế thích hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được định nghĩa qua `FontSubstRule`, những quy tắc đó cũng được cân nhắc.

Bạn cũng có thể thêm phông chữ tại thời gian chạy của ứng dụng, sử dụng phông chữ nhúng từ bản trình chiếu, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như tệp PDF.

## **Lựa chọn phông chữ**

Một số quy tắc nhất định áp dụng cho phông chữ trong bản trình chiếu khi bản trình chiếu được tải, hiển thị hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình chiếu (các slide của nó) thành hình ảnh, các phông chữ của bản trình chiếu sẽ được kiểm tra để xác minh rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/cpp/font-replacement/) và [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/cpp/font-substitution/).

Đây là quy trình mà Aspose.Slides thực hiện khi xử lý phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ khớp với phông chữ đã chọn của bản trình chiếu. 
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sẽ sử dụng nó. Nếu không, Aspose.Slides sẽ sử dụng một phông chữ thay thế gần nhất có thể với những gì PowerPoint sẽ sử dụng.
3. Nếu các quy tắc thay thế phông chữ đã được thiết lập qua [FontSubstRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsubstrule/), chúng sẽ được áp dụng. 

Aspose.Slides cho phép bạn thêm phông chữ vào thời gian chạy của ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](https://docs.aspose.com/slides/vi/cpp/custom-font/). 

Khi các phông chữ bổ sung được đưa vào trong bản trình chiếu, chúng được gọi là [**Phông chữ nhúng**](https://docs.aspose.com/slides/vi/cpp/embedded-font/).

Aspose.Slides cho phép bạn thêm phông chữ chỉ áp dụng cho các tài liệu đầu ra. Ví dụ, nếu một bản trình chiếu bạn muốn chuyển đổi sang PDF chứa các phông chữ thiếu trong hệ thống và phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **phông chữ bên ngoài**. 

{{% alert title="Note" color="primary" %}} 
Chúng tôi không phân phối bất kỳ phông chữ nào, dù là trả phí hay miễn phí. API của chúng tôi cho phép bạn tải phông chữ bên ngoài và nhúng chúng vào tài liệu, nhưng bạn phải thực hiện việc này với phông chữ theo quyết định và trách nhiệm của mình.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xác định các phông chữ thực sự được sử dụng trong bản trình chiếu trước khi chuyển đổi?**

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng thông qua [font manager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_fontsmanager/), vì vậy bạn có thể quyết định có nên [nhúng](/slides/vi/cpp/embedded-font/), [thay thế](/slides/vi/cpp/font-replacement/) hay thêm [nguồn bên ngoài](/slides/vi/cpp/custom-font/). Điều này giúp bạn ngăn ngừa các sự thay thế không mong muốn trong quá trình hiển thị và xuất.

**Tôi có thể thêm các thư mục phông chữ bổ sung mà không cài đặt chúng trên hệ điều hành không?**

Có. Bạn có thể đăng ký [nguồn phông chữ bên ngoài](/slides/vi/cpp/custom-font/) như thư mục hoặc luồng bộ nhớ trong để hiển thị và xuất. Điều này loại bỏ phụ thuộc vào phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

**Làm sao tôi ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?**

Xác định trước [thay thế phông chữ](/slides/vi/cpp/font-replacement/) và [quy tắc fallBack](/slides/vi/cpp/fallback-font/) cho phông chữ một cách rõ ràng. Bằng cách phân tích các phông chữ đã sử dụng và thiết lập ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán về kiểu chữ và tránh các kết quả không mong muốn.