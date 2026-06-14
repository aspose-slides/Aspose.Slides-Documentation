---
title: Chuỗi lựa chọn phông chữ trong Aspose.Slides cho PHP
linktitle: Lựa chọn phông chữ
type: docs
weight: 80
url: /vi/php-java/font-selection-sequence/
keywords:
- lựa chọn phông chữ
- thay thế phông chữ
- thay thế phông chữ
- quy tắc thay thế
- phông chữ có sẵn
- phông chữ thiếu
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho PHP thông qua Java chọn phông chữ, đảm bảo bản trình bày PPT, PPTX và ODP sắc nét, nhất quán — cải thiện slide của bạn ngay hôm nay."
---
## **Tổng quan**

Khi một bản trình bày được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình bày có sẵn trên hệ điều hành hay không. Nếu một phông chữ cần thiết thiếu, Aspose.Slides sẽ chọn một phông chữ thay thế gần nhất có thể so với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides đầu tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu phông chữ được tìm thấy, nó sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế thích hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được định nghĩa qua `FontSubstRule`, các quy tắc đó cũng được tính đến.

Bạn cũng có thể thêm phông chữ ở thời gian chạy của ứng dụng, sử dụng phông chữ nhúng từ bản trình bày, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như tệp PDF.

## **Lựa chọn phông chữ**

Một số quy tắc áp dụng cho phông chữ trong bản trình bày khi bản trình bày được tải, hiển thị hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình bày (các slide) sang hình ảnh, các phông chữ của bản trình bày sẽ được kiểm tra để xác nhận rằng các phông chữ đã chọn có sẵn trên hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế—xem [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/php-java/font-replacement/) và [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/php-java/font-substitution/).

Đây là quy trình Aspose.Slides tuân theo khi xử lý phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ khớp với phông chữ đã chọn trong bản trình bày. 
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sẽ sử dụng nó. Nếu không, Aspose.Slides sẽ sử dụng một phông chữ thay thế gần nhất có thể so với phông chữ mà PowerPoint sẽ sử dụng. 
3. Nếu các quy tắc thay thế phông chữ đã được đặt qua [FontSubstRule](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsubstrule/), chúng sẽ được áp dụng.

Aspose.Slides cho phép bạn thêm phông chữ vào runtime của Aspose và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](https://docs.aspose.com/slides/vi/php-java/custom-font/).

Khi các phông chữ bổ sung được đặt trong một bản trình bày, chúng được gọi là [**Phông chữ nhúng**](https://docs.aspose.com/slides/vi/php-java/embedded-font/).

Aspose.Slides cho phép bạn thêm phông chữ chỉ áp dụng cho *các tài liệu đầu ra*. Ví dụ, nếu một bản trình bày bạn muốn chuyển đổi sang PDF chứa các phông chữ thiếu trên hệ thống và phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **Phông chữ bên ngoài**. 

## **Câu hỏi thường gặp**

**Làm thế nào để xác định các phông chữ thực tế được sử dụng trong một bản trình bày trước khi chuyển đổi?**

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng qua [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/), vì vậy bạn có thể quyết định liệu có nên [nhúng](/slides/vi/php-java/embedded-font/), [thay thế](/slides/vi/php-java/font-replacement/) hoặc thêm [nguồn bên ngoài](/slides/vi/php-java/custom-font/). Điều này giúp bạn ngăn ngừa các thay thế không mong muốn trong quá trình hiển thị và xuất.

**Tôi có thể thêm các thư mục phông chữ bổ sung mà không cần cài đặt chúng trên hệ điều hành không?**

Có. Bạn có thể đăng ký [nguồn phông chữ bên ngoài](/slides/vi/php-java/custom-font/) như thư mục hoặc luồng bộ nhớ cho việc hiển thị và xuất. Điều này loại bỏ sự phụ thuộc vào phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

**Làm thế nào để ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?**

Xác định trước các [quy tắc thay thế phông chữ](/slides/vi/php-java/font-replacement/) và [quy tắc dự phòng phông chữ](/slides/vi/php-java/fallback-font/). Bằng cách phân tích các phông chữ đã dùng và đặt ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán về kiểu chữ và tránh kết quả không mong muốn.