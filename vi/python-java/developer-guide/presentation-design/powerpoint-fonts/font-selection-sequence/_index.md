---
title: Trình tự lựa chọn phông chữ trong Aspose.Slides cho Python qua Java
linktitle: Lựa chọn phông chữ
type: docs
weight: 80
url: /vi/python-java/font-selection-sequence/
keywords:
- lựa chọn phông chữ
- thay thế phông chữ
- thay thế phông chữ
- quy tắc thay thế
- phông chữ khả dụng
- phông chữ thiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Python qua Java chọn phông chữ, đảm bảo trình chiếu PPT, PPTX và ODP sắc nét, nhất quán — cải thiện các slide của bạn ngay."
---
## **Tổng quan**

Khi một bản trình chiếu được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản trình chiếu có sẵn trong hệ điều hành hay không. Nếu phông chữ bắt buộc bị thiếu, Aspose.Slides sẽ chọn một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides đầu tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu phông chữ được tìm thấy, nó sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế phù hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được xác định thông qua [FontSubstRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstrule/), các quy tắc đó cũng sẽ được xem xét.

Bạn cũng có thể thêm phông chữ tại thời điểm chạy ứng dụng, sử dụng phông chữ nhúng từ một bản trình chiếu, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như file PDF.

## **Lựa chọn phông chữ**

Một số quy tắc nhất định áp dụng cho phông chữ trong một bản trình chiếu khi bản trình chiếu được tải, hiển thị hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản trình chiếu (các slide của nó) thành hình ảnh, các phông chữ của bản trình chiếu sẽ được kiểm tra để xác nhận rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [Font Replacement](/slides/vi/python-java/font-replacement/) và [Font Substitution](/slides/vi/python-java/font-substitution/).

Đây là quy trình Aspose.Slides thực hiện khi xử lý phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ phù hợp với phông chữ đã chọn của bản trình chiếu.
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sẽ sử dụng nó. Nếu không, Aspose.Slides sẽ sử dụng một phông chữ thay thế gần nhất có thể với những gì PowerPoint sẽ sử dụng.
3. Nếu các quy tắc thay thế phông chữ đã được thiết lập thông qua [FontSubstRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstrule/), chúng sẽ được áp dụng.

Aspose.Slides cho phép bạn thêm phông chữ tại thời điểm chạy ứng dụng và sau đó sử dụng các phông chữ đó. Xem [Custom fonts](/slides/vi/python-java/custom-font/).

Khi các phông chữ bổ sung được đặt trong một bản trình chiếu, chúng được gọi là [Embedded fonts](/slides/vi/python-java/embedded-font/).

Aspose.Slides cho phép bạn thêm phông chữ chỉ được áp dụng *cho* các tài liệu đầu ra. Ví dụ, nếu một bản trình chiếu bạn muốn chuyển đổi sang PDF sử dụng các phông chữ mà không được cài đặt trên hệ thống của bạn và cũng không được nhúng trong bản trình chiếu, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **phông chữ bên ngoài**.

{{% alert title="Note" color="info" %}}
Chúng tôi không phân phối bất kỳ phông chữ nào, dù là trả phí hay miễn phí. API của chúng tôi cho phép bạn tải phông chữ bên ngoài và nhúng chúng vào tài liệu, nhưng bạn phải tự quyết định và chịu trách nhiệm.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xác định những phông chữ thực sự được sử dụng trong một bản trình chiếu trước khi chuyển đổi?**

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng thông qua [font manager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/), để bạn có thể quyết định có nên [embed](/slides/vi/python-java/embedded-font/), [replace](/slides/vi/python-java/font-replacement/), hoặc thêm [external sources](/slides/vi/python-java/custom-font/). Điều này giúp bạn ngăn ngừa các sự thay thế không mong muốn trong quá trình hiển thị và xuất khẩu.

**Tôi có thể thêm các thư mục phông chữ bổ sung mà không cần cài đặt chúng trên hệ điều hành không?**

Có. Bạn có thể đăng ký [external font sources](/slides/vi/python-java/custom-font/) như thư mục hoặc luồng bộ nhớ trong để hiển thị và xuất khẩu. Điều này loại bỏ phụ thuộc vào phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

**Làm thế nào để tôi ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?**

Xác định rõ ràng [font replacement](/slides/vi/python-java/font-replacement/) và các [fallback rules](/slides/vi/python-java/fallback-font/) cho phông chữ từ trước. Bằng cách phân tích các phông chữ được sử dụng và đặt mức ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán trong kiểu chữ và tránh các kết quả không mong muốn.