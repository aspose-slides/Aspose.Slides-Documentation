---
title: Cấp phép theo tiêu thụ
type: docs
weight: 100
url: /vi/php-java/metered-licensing/
keywords:
- giấy phép
- giấy phép theo tiêu thụ
- khóa giấy phép
- khóa công khai
- khóa riêng
- số lượng tiêu thụ
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides cho PHP thông qua Java và giấy phép theo tiêu thụ cho phép bạn xử lý các tệp PowerPoint và OpenDocument một cách linh hoạt, chỉ trả tiền cho những gì bạn sử dụng."
---
## **Giới thiệu**

Giấy phép theo tiêu thụ là một cơ chế cấp phép có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn được tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép theo tiêu thụ.

## **Áp dụng khóa theo tiêu thụ**

Khi bạn mua giấy phép theo tiêu thụ, bạn nhận được các khóa (không phải tệp giấy phép). Khóa theo tiêu thụ này có thể được áp dụng bằng lớp [Metered](https://reference.aspose.com/slides/vi/php-java/aspose.slides/metered/) do Aspose cung cấp cho các hoạt động đo lường. Để biết thêm chi tiết, xem [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Tạo một thể hiện của lớp [Metered](https://reference.aspose.com/slides/vi/php-java/aspose.slides/metered/).

1. Truyền các khóa công khai và riêng tư của bạn vào phương thức [setMeteredKey](https://reference.aspose.com/slides/vi/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Thực hiện một số xử lý (thực hiện các tác vụ).

1. Gọi phương thức [getConsumptionQuantity](https://reference.aspose.com/slides/vi/php-java/aspose.slides/metered/#getConsumptionQuantity--) của lớp `Metered`.

Bạn sẽ thấy số lượng yêu cầu API bạn đã tiêu thụ cho đến nay.

Đoạn mã mẫu này cho bạn thấy cách sử dụng giấy phép theo tiêu thụ:

```php
// Tạo một thể hiện của lớp Metered
$metered = new Metered();

try {
    // Truyền các khóa công khai và riêng tư vào đối tượng Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Lấy giá trị số lượng tiêu thụ trước các cuộc gọi API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Thực hiện một số thao tác với API Aspose.Slides tại đây
    // ...

    // Lấy giá trị số lượng tiêu thụ sau các cuộc gọi API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Để sử dụng giấy phép theo tiêu thụ, bạn cần có kết nối internet ổn định vì cơ chế cấp phép sử dụng internet để luôn tương tác với dịch vụ của chúng tôi và thực hiện các phép tính.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng giấy phép theo tiêu thụ cùng với giấy phép thường (vĩnh viễn hoặc tạm thời) trong cùng một ứng dụng không?**

Có. Giấy phép theo tiêu thụ là một cơ chế cấp phép bổ sung có thể được sử dụng cùng với các [phương pháp cấp phép](/slides/vi/php-java/licensing/). Bạn chọn cơ chế nào sẽ áp dụng khi ứng dụng khởi động.

**Cụ thể, những gì được tính là tiêu thụ trong giấy phép theo tiêu thụ: các thao tác hay các tệp?**

Việc sử dụng API được tính, nghĩa là số lượng yêu cầu hoặc thao tác. Bạn có thể lấy thông tin tiêu thụ hiện tại thông qua [các phương pháp theo dõi tiêu thụ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/metered/).

**Giấy phép theo tiêu thụ có phù hợp với các môi trường microservices và serverless, nơi các instance thường được khởi động lại không?**

Có. Vì việc tính toán được thực hiện ở mức cuộc gọi API, các kịch bản có khởi động lại lạnh thường xuyên vẫn tương thích, miễn là có kết nối mạng ổn định cho các phép tính của giấy phép theo tiêu thụ.

**Chức năng của thư viện có khác nhau khi sử dụng giấy phép theo tiêu thụ so với giấy phép vĩnh viễn không?**

Không. Điều này chỉ liên quan đến cơ chế cấp phép và thanh toán; khả năng của sản phẩm vẫn như nhau.

**Giấy phép theo tiêu thụ liên quan như thế nào đến phiên bản dùng thử và giấy phép tạm thời?**

Phiên bản dùng thử có giới hạn và watermark, [giấy phép tạm thời](https://purchase.aspose.com/temporary-license/) loại bỏ các giới hạn trong 30 ngày, và giấy phép theo tiêu thụ loại bỏ giới hạn và tính phí dựa trên việc sử dụng thực tế.

**Tôi có thể kiểm soát ngân sách bằng cách tự động phản hồi khi ngưỡng tiêu thụ bị vượt quá không?**

Có. Thực hành phổ biến là đọc định kỳ tiêu thụ hiện tại thông qua [các phương pháp theo dõi](https://reference.aspose.com/slides/vi/php-java/aspose.slides/metered/) và triển khai các giới hạn hoặc cảnh báo của riêng bạn ở mức ứng dụng hoặc giám sát.