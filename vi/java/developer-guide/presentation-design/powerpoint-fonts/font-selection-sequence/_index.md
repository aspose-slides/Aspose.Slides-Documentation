---
title: "Chuỗi lựa chọn phông chữ trong Aspose.Slides cho Java"
linktitle: "Lựa chọn phông chữ"
type: docs
weight: 80
url: /vi/java/font-selection-sequence/
keywords:
- lựa chọn phông chữ
- thay thế phông chữ
- thay thế phông chữ
- quy tắc thay thế
- phông chữ có sẵn
- phông chữ thiếu
- PowerPoint
- OpenDocument
- bản thuyết trình
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Java lựa chọn phông chữ, đảm bảo trình bày PPT, PPTX và ODP rõ nét, đồng nhất - cải thiện các slide của bạn ngay."
---
## **Tổng quan**

Khi một bản thuyết trình được tải, hiển thị hoặc chuyển đổi sang định dạng khác, Aspose.Slides kiểm tra xem các phông chữ được sử dụng trong bản thuyết trình có có sẵn trong hệ điều hành hay không. Nếu một phông chữ cần thiết bị thiếu, Aspose.Slides sẽ chọn một phông chữ thay thế gần nhất có thể với phông chữ mà PowerPoint sẽ sử dụng.

Aspose.Slides đầu tiên tìm kiếm phông chữ đã chọn trong hệ điều hành. Nếu phông chữ được tìm thấy, nó sẽ được sử dụng. Nếu không tìm thấy, một phông chữ thay thế thích hợp sẽ được áp dụng. Khi các quy tắc thay thế phông chữ được định nghĩa thông qua `FontSubstRule`, các quy tắc đó cũng sẽ được xem xét.

Bạn cũng có thể thêm phông chữ tại thời điểm chạy của ứng dụng, sử dụng phông chữ nhúng từ bản thuyết trình, hoặc tải phông chữ bên ngoài cho các tài liệu đầu ra như tệp PDF.

## **Lựa chọn phông chữ**

Một số quy tắc nhất định áp dụng cho phông chữ trong bản thuyết trình khi bản thuyết trình được tải, hiển thị hoặc chuyển đổi sang định dạng khác. Ví dụ, khi bạn cố gắng chuyển đổi một bản thuyết trình (các slide của nó) thành hình ảnh, các phông chữ của bản thuyết trình sẽ được kiểm tra để xác minh rằng các phông chữ đã chọn có sẵn trong hệ điều hành. Nếu các phông chữ được xác nhận là thiếu, chúng sẽ được thay thế — xem [**Font Replacement**](https://docs.aspose.com/slides/vi/java/font-replacement/) và [**Font Substitution**](https://docs.aspose.com/slides/vi/java/font-substitution/).

Quá trình này là cách Aspose.Slides xử lý phông chữ:

1. Aspose.Slides tìm kiếm phông chữ trong hệ điều hành để tìm phông chữ khớp với phông chữ đã chọn của bản thuyết trình. 
2. Nếu phông chữ đã chọn được tìm thấy, Aspose.Slides sẽ sử dụng nó. Nếu không, Aspose.Slides sẽ sử dụng một phông chữ thay thế gần nhất có thể với những gì PowerPoint sẽ sử dụng.
3. Nếu các quy tắc thay thế phông chữ đã được thiết lập thông qua [FontSubstRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstrule/), chúng sẽ được áp dụng. 

Aspose.Slides cho phép bạn thêm phông chữ vào thời gian chạy của ứng dụng và sau đó sử dụng các phông chữ đó. Xem [**Custom fonts**](https://docs.aspose.com/slides/vi/java/custom-font/). 

Khi các phông chữ bổ sung được đặt trong một bản thuyết trình, chúng được gọi là [**Embedded fonts**](https://docs.aspose.com/slides/vi/java/embedded-font/).

Aspose.Slides cho phép bạn thêm phông chữ chỉ được áp dụng cho các tài liệu đầu ra. Ví dụ, nếu một bản thuyết trình mà bạn muốn chuyển đổi sang PDF chứa các phông chữ thiếu trên hệ thống và các phông chữ nhúng, bạn có thể thêm hoặc tải các phông chữ cần thiết dưới dạng **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Chúng tôi không phân phối bất kỳ phông chữ nào, dù là trả phí hay miễn phí. API của chúng tôi cho phép bạn tải phông chữ bên ngoài và nhúng chúng vào tài liệu, nhưng bạn phải tự chịu trách nhiệm và quyết định việc sử dụng phông chữ.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xác định những phông chữ thực sự được sử dụng trong một bản thuyết trình trước khi chuyển đổi?**

Aspose.Slides cho phép bạn kiểm tra các phông chữ được sử dụng thông qua [font manager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/), vì vậy bạn có thể quyết định có nên [embed](/slides/vi/java/embedded-font/), [replace](/slides/vi/java/font-replacement/), hoặc thêm [external sources](/slides/vi/java/custom-font/). Điều này giúp bạn ngăn ngừa việc thay thế không mong muốn trong quá trình hiển thị và xuất.

**Tôi có thể thêm các thư mục phông chữ phụ trợ mà không cần cài đặt chúng trên hệ điều hành không?**

Có. Bạn có thể đăng ký [external font sources](/slides/vi/java/custom-font/) như thư mục hoặc luồng bộ nhớ trong để hiển thị và xuất. Điều này loại bỏ sự phụ thuộc vào phông chữ của hệ thống máy chủ và giữ cho bố cục dự đoán được.

**Làm thế nào để tôi ngăn chặn việc tự động chuyển sang phông chữ không phù hợp khi một glyph bị thiếu?**

Xác định trước các [font replacement](/slides/vi/java/font-replacement/) và [fallback rules](/slides/vi/java/fallback-font/) một cách rõ ràng. Bằng cách phân tích các phông chữ đã sử dụng và thiết lập ưu tiên kiểm soát cho các phông chữ thay thế, bạn đảm bảo tính nhất quán trong typography và tránh các kết quả không mong muốn.