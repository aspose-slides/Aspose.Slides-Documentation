---
title: "Quy trình lựa chọn phông chữ trong Aspose.Slides cho Node.js qua Java"
linktitle: "Lựa chọn phông chữ"
type: docs
weight: 80
url: /vi/nodejs-java/font-selection-sequence/
keywords:
- "lựa chọn phông chữ"
- "thay thế phông chữ"
- "thay thế phông chữ"
- "quy tắc thay thế"
- "phông chữ có sẵn"
- "phông chữ bị thiếu"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Khám phá cách Aspose.Slides cho Node.js qua Java chọn phông chữ, đảm bảo hiển thị sắc nét, nhất quán cho các tệp PPT, PPTX và ODP—cải thiện slide của bạn ngay bây giờ."
---
## **Tổng quan**

Khi một bản trình bày được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình bày có có sẵn trong hệ điều hành hay không. Nếu một phông chữ yêu cầu bị thiếu, Aspose.Slides chọn một phông chữ thay thế càng gần càng tốt với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides đầu tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu tìm thấy, nó sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế phù hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được xác định qua `FontSubstRule`, những quy tắc đó cũng sẽ được tính đến.

Bạn cũng có thể thêm phông chữ tại thời gian chạy của ứng dụng, sử dụng phông chữ nhúng từ một bản trình bày, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như file PDF.

## **Lựa chọn phông chữ**

Một số quy tắc áp dụng cho phông chữ trong bản trình bày khi bản trình bày được tải, hiển thị hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình bày (các slide) sang hình ảnh, các phông chữ của bản trình bày sẽ được kiểm tra để xác nhận rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/nodejs-java/font-replacement/) và [**Thay thế phông chữ (Substitution)**](https://docs.aspose.com/slides/vi/nodejs-java/font-substitution/).

Đây là quy trình Aspose.Slides tuân theo khi xử lý phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ khớp với phông chữ đã chọn trong bản trình bày. 
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sử dụng nó. Nếu không, Aspose.Slides sử dụng một phông chữ thay thế càng gần càng tốt với phông chữ mà PowerPoint sẽ sử dụng.
3. Nếu các quy tắc thay thế phông chữ đã được thiết lập qua [FontSubstRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsubstrule/), chúng sẽ được áp dụng.

Aspose.Slides cho phép bạn thêm phông chữ vào thời gian chạy của ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](https://docs.aspose.com/slides/vi/nodejs-java/custom-font/).

Khi các phông chữ bổ sung được đặt trong một bản trình bày, chúng được gọi là [**Phông chữ nhúng**](https://docs.aspose.com/slides/vi/nodejs-java/embedded-font/).

Aspose.Slides cho phép bạn thêm các phông chữ chỉ được áp dụng cho các tài liệu đầu ra. Ví dụ, nếu một bản trình bày mà bạn muốn chuyển đổi sang PDF chứa các phông chữ bị thiếu trong hệ thống và các phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết như **phông chữ bên ngoài**. 

{{% alert title="Note" color="primary" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xác định các phông chữ thực tế được sử dụng trong một bản trình bày trước khi chuyển đổi?**

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng qua [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getfontsmanager/), vì vậy bạn có thể quyết định [nhúng](/slides/vi/nodejs-java/embedded-font/), [thay thế](/slides/vi/nodejs-java/font-replacement/) hoặc thêm [nguồn bên ngoài](/slides/vi/nodejs-java/custom-font/). Điều này giúp bạn ngăn ngừa các sự thay thế không mong muốn trong quá trình hiển thị và xuất.

**Tôi có thể thêm các thư mục phông chữ phụ trợ mà không cần cài đặt chúng trên hệ điều hành không?**

Có. Bạn có thể đăng ký [nguồn phông chữ bên ngoài](/slides/vi/nodejs-java/custom-font/) như thư mục hoặc luồng bộ nhớ để hiển thị và xuất. Điều này loại bỏ phụ thuộc vào phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

**Làm sao để ngăn ngừa việc tự động chuyển sang một phông chữ không phù hợp khi một glyph bị thiếu?**

Xác định rõ ràng [các quy tắc thay thế phông chữ](/slides/vi/nodejs-java/font-replacement/) và [các quy tắc font fallBack](/slides/vi/nodejs-java/fallback-font/) từ trước. Bằng cách phân tích các phông chữ đã dùng và thiết lập mức ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán về kiểu chữ và tránh kết quả không mong muốn.