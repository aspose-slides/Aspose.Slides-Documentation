---
title: Cấp phép tính theo mức dùng
type: docs
weight: 100
url: /vi/java/metered-licensing/
keywords:
- giấy phép
- giấy phép tính theo mức dùng
- khóa giấy phép
- khóa công khai
- khóa riêng
- số lượng tiêu thụ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách cấp phép tính theo mức dùng của Aspose.Slides cho Java cho phép bạn xử lý các tệp PowerPoint và OpenDocument một cách linh hoạt, chỉ trả phí cho những gì bạn sử dụng."
---
## **Giới thiệu**

Giấy phép tính theo mức dùng là một cơ chế cấp phép có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn bị tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép tính theo mức dùng.

## **Áp dụng khóa tính theo mức dùng**

{{% alert color="info" %}} 

Giấy phép tính theo mức dùng là một cơ chế cấp phép mới có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn bị tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép tính theo mức dùng.

Khi bạn mua giấy phép tính theo mức dùng, bạn nhận được các khóa (không phải tệp giấy phép). Khóa này có thể được áp dụng bằng cách sử dụng lớp [Metered](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/) do Aspose cung cấp cho các thao tác tính mức dùng. Để biết thêm chi tiết, xem [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Tạo một thể hiện của lớp [Metered](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/).

1. Gửi khóa công khai và khóa riêng của bạn tới phương thức [setMeteredKey](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Thực hiện một số xử lý (thực hiện các tác vụ).

1. Gọi phương thức [getConsumptionQuantity](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/#getConsumptionQuantity--) của lớp `Metered`.

Bạn sẽ thấy số lượng/yêu cầu API đã tiêu thụ cho đến nay.

Mã mẫu này cho bạn thấy cách sử dụng giấy phép tính theo mức dùng:

```java
// Tạo một thể hiện của lớp Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Gửi khóa công khai và khóa riêng tới đối tượng Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Lấy giá trị số lượng đã tiêu thụ trước các lời gọi API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Thực hiện một việc gì đó với API Aspose.Slides ở đây
    // ...

    // Lấy giá trị số lượng đã tiêu thụ sau các lời gọi API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Để sử dụng giấy phép tính theo mức dùng, bạn cần một kết nối internet ổn định vì cơ chế cấp phép sử dụng internet để liên tục tương tác với dịch vụ của chúng tôi và thực hiện các phép tính.

{{% /alert %}} 

## **Câu hỏi thường gặp**

### Tôi có thể sử dụng giấy phép tính theo mức dùng cùng với giấy phép thường (vĩnh viễn hoặc tạm thời) trong cùng một ứng dụng không?

Có. Metered là một cơ chế cấp phép bổ sung có thể được sử dụng cùng với [các phương pháp cấp phép](/slides/vi/java/licensing/). Bạn chọn cơ chế nào sẽ áp dụng khi ứng dụng khởi động.

### Chính xác việc tiêu thụ trong giấy phép tính theo mức dùng là gì: các thao tác hay tệp tin?

Việc sử dụng API được tính, nghĩa là số lượng yêu cầu hoặc thao tác. Bạn có thể lấy mức tiêu thụ hiện tại qua [các phương pháp theo dõi tiêu thụ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/).

### Liệu Metered có phù hợp cho môi trường microservices và serverless mà các instance thường khởi động lại không?

Có. Vì việc tính toán được thực hiện ở mức cuộc gọi API, các kịch bản có khởi động lại thường xuyên (cold start) vẫn tương thích, với điều kiện có kết nối mạng ổn định cho các phép tính tính theo mức dùng.

### Chức năng của thư viện có khác khi sử dụng giấy phép tính theo mức dùng so với giấy phép vĩnh viễn không?

Không. Điều này chỉ liên quan tới cơ chế cấp phép và thanh toán; khả năng của sản phẩm vẫn giống nhau.

### Metered liên quan như thế nào tới phiên bản dùng thử và giấy phép tạm thời?

Phiên bản dùng thử có các hạn chế và dấu watermark, [giấy phép tạm thời](https://purchase.aspose.com/temporary-license/) loại bỏ các hạn chế trong 30 ngày, và Metered loại bỏ hạn chế và tính phí dựa trên việc sử dụng thực tế.

### Tôi có thể kiểm soát ngân sách bằng cách tự động phản hồi khi ngưỡng tiêu thụ vượt quá không?

Có. Thực hành phổ biến là đọc định kỳ mức tiêu thụ hiện tại qua [các phương pháp theo dõi](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/) và triển khai các giới hạn hoặc cảnh báo của riêng bạn ở cấp ứng dụng hoặc giám sát.