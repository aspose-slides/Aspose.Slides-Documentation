---
title: "Quy trình lựa chọn phông chữ trong Aspose.Slides cho .NET"
linktitle: "Lựa chọn phông chữ"
type: docs
weight: 80
url: /vi/net/font-selection-sequence/
keywords:
- "lựa chọn phông chữ"
- "thay thế phông chữ"
- "thay đổi phông chữ"
- "quy tắc thay thế"
- "phông chữ có sẵn"
- "phông chữ thiếu"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Khám phá cách Aspose.Slides cho .NET chọn phông chữ, đảm bảo bản trình bày PPT, PPTX và ODP sắc nét, nhất quán — cải thiện slide của bạn ngay."
---
## **Tổng quan**

Khi một bản trình bày được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình bày có có sẵn trong hệ điều hành hay không. Nếu một phông chữ cần thiết thiếu, Aspose.Slides sẽ chọn một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides trước tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu tìm thấy, phông chữ sẽ được sử dụng. Nếu không tìm thấy, sẽ áp dụng một phông chữ thay thế phù hợp. Khi các quy tắc thay thế phông chữ được định nghĩa qua `FontSubstRule`, những quy tắc đó cũng được xem xét.

Bạn cũng có thể thêm phông chữ tại thời gian chạy của ứng dụng, sử dụng phông chữ nhúng từ bản trình bày, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như tệp PDF.

## **Lựa chọn phông chữ**

Một số quy tắc áp dụng cho phông chữ trong bản trình bày khi bản trình bày được tải, hiển thị hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình bày (các slide) sang hình ảnh, các phông chữ của bản trình bày sẽ được kiểm tra để xác nhận rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/net/font-replacement/) và [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/net/font-substitution/).

Đây là quy trình Aspose.Slides thực hiện khi xử lý phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ khớp với phông chữ đã chọn trong bản trình bày.  
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sử dụng nó. Nếu không, Aspose.Slides sẽ sử dụng một phông chữ thay thế càng gần càng tốt với phông chữ mà PowerPoint sẽ dùng.  
3. Nếu các quy tắc thay thế phông chữ đã được đặt qua [FontSubstRule](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsubstrule/), chúng sẽ được áp dụng.  

Aspose.Slides cho phép bạn thêm phông chữ vào thời gian chạy của ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](https://docs.aspose.com/slides/vi/net/custom-font/).

Khi các phông chữ bổ sung được đặt trong một bản trình bày, chúng được gọi là [**Phông chữ nhúng**](https://docs.aspose.com/slides/vi/net/embedded-font/).

Aspose.Slides cho phép bạn thêm các phông chữ chỉ được áp dụng cho tài liệu đầu ra. Ví dụ, nếu một bản trình bày mà bạn muốn chuyển đổi sang PDF chứa các phông chữ thiếu trên hệ thống và phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **phông chữ bên ngoài**. 

{{% alert title="Lưu ý" color="info" %}} 
Chúng tôi không phân phối bất kỳ phông chữ nào, dù là trả phí hay miễn phí. API của chúng tôi cho phép bạn tải các phông chữ bên ngoài và nhúng chúng vào tài liệu, nhưng việc này bạn thực hiện với phông chữ do bạn tự lựa chọn và chịu trách nhiệm. 
{{% /alert %}}

## **Câu hỏi thường gặp**

### Làm thế nào để tôi xác định các phông chữ thực sự được sử dụng trong bản trình bày trước khi chuyển đổi?

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng qua [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/fontsmanager/), vì vậy bạn có thể quyết định [nhúng](/slides/vi/net/embedded-font/), [thay thế](/slides/vi/net/font-replacement/), hoặc thêm [nguồn bên ngoài](/slides/vi/net/custom-font/). Điều này giúp ngăn ngừa các sự thay thế không mong muốn trong quá trình hiển thị và xuất.

### Tôi có thể thêm các thư mục phông chữ bổ sung mà không cần cài đặt chúng trên hệ điều hành không?

Có. Bạn có thể đăng ký [nguồn phông chữ bên ngoài](/slides/vi/net/custom-font/) như thư mục hoặc luồng bộ nhớ để hiển thị và xuất. Điều này loại bỏ phụ thuộc vào phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

### Làm sao để ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?

Xác định trước các [quy tắc thay thế phông chữ](/slides/vi/net/font-replacement/) và [quy tắc fallback phông chữ](/slides/vi/net/fallback-font/). Bằng cách phân tích các phông chữ đã dùng và thiết lập mức ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán về kiểu chữ và tránh các kết quả không mong muốn.