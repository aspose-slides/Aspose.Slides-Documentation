---
title: Trình tự lựa chọn phông chữ trong Aspose.Slides cho Android qua Java
linktitle: Lựa chọn phông chữ
type: docs
weight: 80
url: /vi/androidjava/font-selection-sequence/
keywords:
- lựa chọn phông chữ
- thay thế phông chữ
- thay đổi phông chữ
- quy tắc thay thế
- phông chữ khả dụng
- phông chữ bị thiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Android qua Java chọn phông chữ, đảm bảo bản trình chiếu PPT, PPTX và ODP sắc nét, nhất quán — nâng cao các slide của bạn ngay hôm nay."
---
## **Tổng quan**

Khi một bản trình chiếu được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình chiếu có có sẵn trong hệ điều hành không. Nếu một phông chữ bắt buộc bị thiếu, Aspose.Slides sẽ chọn một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides đầu tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu tìm thấy, nó sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế phù hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được định nghĩa thông qua `FontSubstRule`, các quy tắc đó cũng sẽ được tính đến.

Bạn cũng có thể thêm phông chữ tại thời gian chạy của ứng dụng, sử dụng phông chữ nhúng từ bản trình chiếu, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như tệp PDF.

## **Lựa chọn phông chữ**

Một số quy tắc áp dụng cho phông chữ trong bản trình chiếu khi bản trình chiếu được tải, hiển thị hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình chiếu (các slide của nó) thành hình ảnh, các phông chữ của bản trình chiếu sẽ được kiểm tra để xác nhận rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/androidjava/font-replacement/) và [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/androidjava/font-substitution/).

Đây là quy trình Aspose.Slides thực hiện khi làm việc với phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ khớp với phông chữ đã chọn trong bản trình chiếu. 
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sẽ sử dụng nó. Nếu không, Aspose.Slides sẽ sử dụng một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.
3. Nếu các quy tắc thay thế phông chữ đã được thiết lập qua [FontSubstRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsubstrule/), chúng sẽ được áp dụng.

Aspose.Slides cho phép bạn thêm phông chữ vào thời gian chạy của ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](https://docs.aspose.com/slides/vi/androidjava/custom-font/).

Khi các phông chữ bổ sung được đặt trong một bản trình chiếu, chúng được gọi là [**Phông chữ nhúng**](https://docs.aspose.com/slides/vi/androidjava/embedded-font/).

Aspose.Slides cho phép bạn thêm các phông chữ chỉ được áp dụng cho *các tài liệu đầu ra*. Ví dụ, nếu một bản trình chiếu mà bạn muốn chuyển đổi sang PDF chứa các phông chữ thiếu trong hệ thống và các phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết như **phông chữ bên ngoài**. 

{{% alert title="Note" color="info" %}} 
Chúng tôi không phân phối bất kỳ phông chữ nào, dù là trả phí hay miễn phí. API của chúng tôi cho phép bạn tải phông chữ bên ngoài và nhúng chúng vào tài liệu, nhưng bạn phải tự chịu trách nhiệm và quyết định việc sử dụng phông chữ.
{{% /alert %}}

## **Câu hỏi thường gặp**

### Làm thế nào tôi có thể xác định các phông chữ thực sự được sử dụng trong một bản trình chiếu trước khi chuyển đổi?

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng thông qua [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/), vì vậy bạn có thể quyết định có nên [nhúng](/slides/vi/androidjava/embedded-font/), [thay thế](/slides/vi/androidjava/font-replacement/) hoặc thêm [nguồn bên ngoài](/slides/vi/androidjava/custom-font/). Điều này giúp bạn ngăn ngừa các sự thay thế không mong muốn trong quá trình hiển thị và xuất.

### Tôi có thể thêm các thư mục phông chữ bổ sung mà không cần cài đặt chúng trên hệ điều hành không?

Có. Bạn có thể đăng ký [nguồn phông chữ bên ngoài](/slides/vi/androidjava/custom-font/) như thư mục hoặc luồng bộ nhớ trong để hiển thị và xuất. Điều này loại bỏ sự phụ thuộc vào phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

### Làm sao để ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?

Xác định trước các [quy tắc thay thế phông chữ](/slides/vi/androidjava/font-replacement/) và [quy tắc dự phòng phông chữ](/slides/vi/androidjava/fallback-font/). Bằng cách phân tích các phông chữ đã sử dụng và thiết lập độ ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán về kiểu chữ và tránh kết quả không mong muốn.