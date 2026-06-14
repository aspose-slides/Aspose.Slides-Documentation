---
title: Giấy phép tính theo mức
type: docs
weight: 100
url: /vi/java/metered-licensing/
keywords:
- giấy phép
- giấy phép tính theo mức
- khóa giấy phép
- khóa công khai
- khóa riêng
- lượng tiêu thụ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách giấy phép tính theo mức của Aspose.Slides cho Java cho phép bạn xử lý linh hoạt các tệp PowerPoint và OpenDocument, chỉ trả phí cho những gì bạn sử dụng."
---
## **Giới thiệu**

Giấy phép theo mức tiêu thụ là một cơ chế cấp phép có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn bị tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép theo mức tiêu thụ.

## **Áp dụng Khóa Tính Theo Mức**

{{% alert color="primary" %}} 

Giấy phép theo mức tiêu thụ là một cơ chế cấp phép mới có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn bị tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép theo mức tiêu thụ.

Khi bạn mua một giấy phép tính theo mức, bạn nhận được các khóa (không phải tệp giấy phép). Khóa tính theo mức này có thể được áp dụng bằng cách sử dụng lớp [Metered](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/) do Aspose cung cấp cho các thao tác tính mức. Để biết thêm chi tiết, xem [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Tạo một thể hiện của lớp [Metered](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/).

2. Gửi khóa công khai và khóa riêng của bạn vào phương thức [setMeteredKey](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

3. Thực hiện một số xử lý (thực hiện các nhiệm vụ).

4. Gọi phương thức [getConsumptionQuantity](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/#getConsumptionQuantity--) của lớp `Metered`.

Bạn sẽ thấy số lượng yêu cầu API bạn đã tiêu thụ cho tới thời điểm hiện tại.

Đoạn mã mẫu này cho thấy cách sử dụng giấy phép theo mức tiêu thụ:

```java
// Tạo một thể hiện của lớp Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Gửi khóa công khai và khóa riêng cho đối tượng Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Lấy giá trị lượng tiêu thụ trước các cuộc gọi API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Thực hiện một số thao tác với API Aspose.Slides ở đây
    // ...

    // Lấy giá trị lượng tiêu thụ sau các cuộc gọi API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Để sử dụng giấy phép theo mức tiêu thụ, bạn cần một kết nối internet ổn định vì cơ chế cấp phép sử dụng internet để liên tục tương tác với dịch vụ của chúng tôi và thực hiện các phép tính.

{{% /alert %}} 

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng giấy phép theo mức tiêu thụ cùng với giấy phép thường (vĩnh viễn hoặc tạm thời) trong cùng một ứng dụng không?**

Có. Giấy phép theo mức tiêu thụ là một cơ chế cấp phép bổ sung có thể được sử dụng cùng với các [phương pháp cấp phép](/slides/vi/java/licensing/) hiện có. Bạn chọn cơ chế nào sẽ áp dụng khi ứng dụng khởi động.

**Cụ thể, tiêu thụ trong giấy phép theo mức tiêu thụ được tính dựa trên gì: các thao tác hay tệp?**

Việc sử dụng API được tính, nghĩa là số lượng yêu cầu hoặc thao tác. Bạn có thể lấy mức tiêu thụ hiện tại thông qua các [phương pháp theo dõi tiêu thụ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/).

**Giấy phép theo mức tiêu thụ có phù hợp cho môi trường microservices và serverless, nơi các instance thường khởi động lại không?**

Có. Vì việc tính toán được thực hiện ở mức gọi API, các kịch bản có khởi động lạnh thường xuyên vẫn tương thích, với điều kiện có kết nối mạng ổn định để thực hiện các phép tính của giấy phép theo mức tiêu thụ.

**Chức năng của thư viện có khác nhau khi sử dụng giấy phép theo mức tiêu thụ so với giấy phép vĩnh viễn không?**

Không. Điều này chỉ liên quan đến cơ chế cấp phép và thanh toán; các tính năng của sản phẩm vẫn giống nhau.

**Giấy phép theo mức tiêu thụ liên quan như thế nào đến phiên bản dùng thử và giấy phép tạm thời?**

Phiên bản dùng thử có các hạn chế và watermark, [giấy phép tạm thời](https://purchase.aspose.com/temporary-license/) loại bỏ các hạn chế trong 30 ngày, và giấy phép theo mức tiêu thụ loại bỏ hạn chế và tính phí dựa trên mức sử dụng thực tế.

**Tôi có thể kiểm soát ngân sách bằng cách tự động phản hồi khi vượt ngưỡng tiêu thụ không?**

Có. Thực hành phổ biến là đọc định kỳ mức tiêu thụ hiện tại thông qua các [phương pháp theo dõi](https://reference.aspose.com/slides/vi/java/com.aspose.slides/metered/) và tự triển khai các giới hạn hoặc cảnh báo ở cấp ứng dụng hoặc giám sát.