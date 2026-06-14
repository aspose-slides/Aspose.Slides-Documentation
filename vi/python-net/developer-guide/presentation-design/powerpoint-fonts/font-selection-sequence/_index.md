---
title: Trình tự lựa chọn phông chữ trong Aspose.Slides cho Python
linktitle: Lựa chọn phông chữ
type: docs
weight: 80
url: /vi/python-net/font-selection-sequence/
keywords:
- lựa chọn phông chữ
- thay thế phông chữ
- thay thế phông chữ
- quy tắc thay thế
- phông chữ khả dụng
- phông chữ thiếu
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Python qua .NET chọn phông chữ, đảm bảo trình bày PPT, PPTX và ODP sắc nét, nhất quán — cải thiện slide của bạn ngay."
---
## **Tổng quan**

Khi một bản trình bày được tải, render, hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình bày có sẵn trong hệ điều hành hay không. Nếu một phông chữ yêu cầu bị thiếu, Aspose.Slides chọn một phông chữ thay thế gần nhất có thể so với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides đầu tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu tìm thấy, nó sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế phù hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được định nghĩa qua `FontSubstRule`, các quy tắc đó cũng được xem xét.

Bạn cũng có thể thêm phông chữ tại thời gian chạy ứng dụng, sử dụng phông chữ nhúng từ bản trình bày, hoặc tải phông chữ bên ngoài cho các tài liệu xuất như file PDF.

## **Lựa chọn phông chữ**

Một số quy tắc áp dụng cho phông chữ trong bản trình bày khi bản trình bày được tải, render, hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình bày (các slide) sang hình ảnh, các phông chữ của bản trình bày sẽ được kiểm tra để xác nhận rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/python-net/font-replacement/) và [**Thay thế phông chữ**](https://docs.aspose.com/slides/vi/python-net/font-substitution/).

Đây là quy trình mà Aspose.Slides thực hiện khi xử lý phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ khớp với phông chữ đã chọn của bản trình bày. 
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sử dụng nó. Nếu không, Aspose.Slides sử dụng một phông chữ thay thế gần nhất có thể so với những gì PowerPoint sẽ dùng. 
3. Nếu các quy tắc thay thế phông chữ đã được thiết lập qua [FontSubstRule](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsubstrule/), chúng sẽ được áp dụng. 

Aspose.Slides cho phép bạn thêm phông chữ vào thời gian chạy ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Phông chữ tùy chỉnh**](https://docs.aspose.com/slides/vi/python-net/custom-font/). 

Khi các phông chữ bổ sung được đặt trong một bản trình bày, chúng được gọi là [**Phông chữ nhúng**](https://docs.aspose.com/slides/vi/python-net/embedded-font/).

Aspose.Slides cho phép bạn thêm phông chữ chỉ áp dụng cho *tài liệu đầu ra*. Ví dụ, nếu một bản trình bày bạn muốn chuyển đổi sang PDF chứa các phông chữ thiếu trong hệ thống và các phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **phông chữ bên ngoài**. 

{{% alert title="Note" color="primary" %}} 
Chúng tôi không phân phối bất kỳ phông chữ nào, dù là trả phí hay miễn phí. API của chúng tôi cho phép bạn tải phông chữ bên ngoài và nhúng chúng vào tài liệu, nhưng bạn phải tự chịu trách nhiệm và quyết định việc sử dụng phông chữ. 
{{% /alert %}}

## **FAQ**

**Làm sao tôi có thể xác định các phông chữ thực tế được sử dụng trong một bản trình bày trước khi chuyển đổi?**

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng thông qua [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/fonts_manager/), vì vậy bạn có thể quyết định có [nhúng](/slides/vi/python-net/embedded-font/), [thay thế](/slides/vi/python-net/font-replacement/), hoặc thêm [nguồn bên ngoài](/slides/vi/python-net/custom-font/). Điều này giúp bạn ngăn ngừa các thay thế không mong muốn trong quá trình render và xuất.

**Tôi có thể thêm các thư mục phông chữ bổ sung mà không cài đặt chúng trên hệ điều hành không?**

Có. Bạn có thể đăng ký [nguồn phông chữ bên ngoài](/slides/vi/python-net/custom-font/) như thư mục hoặc luồng nhớ trong để render và xuất. Điều này loại bỏ phụ thuộc vào phông chữ hệ thống host và giữ cho bố cục dự đoán được.

**Làm sao tôi ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?**

Xác định rõ ràng [thay thế phông chữ](/slides/vi/python-net/font-replacement/) và các [quy tắc fallback](/slides/vi/python-net/fallback-font/) trước. Bằng cách phân tích các phông chữ đã dùng và thiết lập độ ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính đồng nhất về kiểu chữ và tránh kết quả không mong muốn.