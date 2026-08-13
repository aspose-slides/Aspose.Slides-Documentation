---
title: "Quy Trình Lựa Chọn Phông Chữ trong Aspose.Slides cho Java"
linktitle: "Lựa Chọn Phông Chữ"
type: docs
weight: 80
url: /vi/java/font-selection-sequence/
keywords:
- "lựa chọn phông chữ"
- "thay thế phông chữ"
- "thay thế phông chữ"
- "quy tắc thay thế"
- "phông chữ khả dụng"
- "phông chữ thiếu"
- "PowerPoint"
- "OpenDocument"
- "bài thuyết trình"
- "Java"
- "Aspose.Slides"
description: "Khám phá cách Aspose.Slides cho Java lựa chọn phông chữ, đảm bảo hiển thị sắc nét và nhất quán cho các tệp PPT, PPTX và ODP — cải thiện slide của bạn ngay bây giờ."
---
## **Tổng quan**

Khi một bản trình bày được tải, render hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình bày có có sẵn trong hệ điều hành hay không. Nếu một phông chữ bắt buộc bị thiếu, Aspose.Slides sẽ chọn một phông chữ thay thế sao cho gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides trước tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu tìm thấy, phông chữ sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế thích hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được định nghĩa qua `FontSubstRule`, những quy tắc đó cũng sẽ được tính đến.

Bạn cũng có thể thêm phông chữ tại thời điểm chạy ứng dụng, sử dụng phông chữ nhúng từ một bản trình bày, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như file PDF.

## **Lựa chọn phông chữ**

Có một số quy tắc áp dụng cho phông chữ trong bản trình bày khi bản trình bày được tải, render hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình bày (các slide) sang ảnh, các phông chữ của bản trình bày sẽ được kiểm tra để xác minh rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/java/font-replacement/) và [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/java/font-substitution/).

Đây là quy trình mà Aspose.Slides tuân theo khi làm việc với phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ phù hợp với phông chữ đã chọn trong bản trình bày.  
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sẽ sử dụng nó. Ngược lại, Aspose.Slides sẽ sử dụng một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ dùng.  
3. Nếu các quy tắc thay thế phông chữ đã được thiết lập qua [FontSubstRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstrule/), chúng sẽ được áp dụng.

Aspose.Slides cho phép bạn thêm phông chữ vào thời điểm chạy ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](https://docs.aspose.com/slides/vi/java/custom-font/).

Khi các phông chữ bổ sung được đặt trong một bản trình bày, chúng được gọi là [**Phông chữ nhúng**](https://docs.aspose.com/slides/vi/java/embedded-font/).

Aspose.Slides cho phép bạn thêm các phông chữ chỉ được áp dụng cho *tài liệu đầu ra*. Ví dụ, nếu một bản trình bày bạn đang muốn chuyển đổi sang PDF chứa các phông chữ thiếu trên hệ thống và các phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **phông chữ bên ngoài**.

{{% alert title="Lưu ý" color="info" %}} 
Chúng tôi không phân phối bất kỳ phông chữ nào, dù là trả phí hay miễn phí. API của chúng tôi cho phép bạn tải phông chữ bên ngoài và nhúng chúng vào tài liệu, nhưng việc này bạn thực hiện với phông chữ do bạn tự lựa chọn và chịu trách nhiệm.
{{% /alert %}}

## **Câu hỏi thường gặp**

### Làm thế nào để xác định các phông chữ thực tế được sử dụng trong một bản trình bày trước khi chuyển đổi?

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng qua [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/), vì vậy bạn có thể quyết định có [nhúng](/slides/vi/java/embedded-font/), [thay thế](/slides/vi/java/font-replacement/) hoặc thêm [nguồn bên ngoài](/slides/vi/java/custom-font/). Điều này giúp bạn ngăn ngừa các sự thay thế không mong muốn trong quá trình render và xuất.

### Tôi có thể thêm các thư mục phông chữ bổ sung mà không cần cài đặt chúng trên hệ điều hành không?

Có. Bạn có thể đăng ký [nguồn phông chữ bên ngoài](/slides/vi/java/custom-font/) như thư mục hoặc luồng bộ nhớ trong để render và xuất. Điều này loại bỏ phụ thuộc vào các phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

### Làm sao ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?

Xác định trước [quy tắc thay thế phông chữ](/slides/vi/java/font-replacement/) và [quy tắc dự phòng phông chữ](/slides/vi/java/fallback-font/). Bằng cách phân tích các phông chữ đã sử dụng và thiết lập độ ưu tiên kiểm soát cho các phông thay thế, bạn đảm bảo tính đồng nhất về kiểu chữ và tránh các kết quả không mong muốn.