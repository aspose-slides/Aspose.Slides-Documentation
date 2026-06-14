---
title: Giấy phép tính theo mức tiêu thụ
type: docs
weight: 90
url: /vi/net/metered-licensing/
keywords:
- giấy phép
- giấy phép tính theo mức tiêu thụ
- khóa giấy phép
- khóa công khai
- khóa riêng
- số lượng tiêu thụ
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách giấy phép tính theo mức tiêu thụ của Aspose.Slides cho .NET cho phép bạn xử lý các tệp PowerPoint và OpenDocument một cách linh hoạt, chỉ trả phí cho những gì bạn sử dụng."
---
## **Giới thiệu**

Giấy phép tính theo mức tiêu thụ là một cơ chế cấp phép có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn bị tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép tính theo mức tiêu thụ.

## **Áp dụng khóa tính theo mức tiêu thụ**

Khi bạn mua giấy phép tính theo mức tiêu thụ, bạn sẽ nhận được các khóa (không phải tệp giấy phép). Khóa này có thể được áp dụng bằng lớp [Metered](https://reference.aspose.com/slides/vi/net/aspose.slides/metered/) mà Aspose cung cấp cho các thao tác đo lường. Để biết thêm chi tiết, xem [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Tạo một thể hiện của lớp [Metered](https://reference.aspose.com/slides/vi/net/aspose.slides/metered/).
1. Truyền khóa công khai và khóa riêng của bạn vào phương thức [SetMeteredKey](https://reference.aspose.com/slides/vi/net/aspose.slides/metered/setmeteredkey/).
1. Thực hiện một số xử lý (thực hiện các tác vụ).
1. Gọi phương thức [GetConsumptionQuantity](https://reference.aspose.com/slides/vi/net/aspose.slides/metered/getconsumptionquantity/) của lớp `Metered`.

Bạn sẽ thấy số lượng yêu cầu API đã tiêu thụ cho đến thời điểm hiện tại.

Mã mẫu này cho bạn thấy cách sử dụng giấy phép tính theo mức tiêu thụ:

```cs
// Tạo một thể hiện của lớp Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Truyền khóa công khai và khóa riêng tới đối tượng Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Lấy số lượng dữ liệu đã đo trước khi gọi API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Thực hiện một số thao tác với API Aspose.Slides tại đây
// ...

// Lấy số lượng dữ liệu đã đo sau khi gọi API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 
Để sử dụng giấy phép tính theo mức tiêu thụ, bạn cần một kết nối internet ổn định vì cơ chế cấp phép sử dụng internet để liên tục tương tác với dịch vụ của chúng tôi và thực hiện các phép tính.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng giấy phép tính theo mức tiêu thụ cùng với giấy phép thông thường (vĩnh viễn hoặc tạm thời) trong cùng một ứng dụng không?**

Có. Metered là một cơ chế cấp phép bổ sung có thể được sử dụng cùng với các [phương pháp cấp phép](/slides/vi/net/licensing/) hiện có. Bạn chọn cơ chế nào sẽ áp dụng khi ứng dụng khởi chạy.

**Điều gì được tính là tiêu thụ trong giấy phép tính theo mức tiêu thụ: các thao tác hay tệp?**

Việc sử dụng API được tính, nghĩa là số lượng yêu cầu hoặc thao tác. Bạn có thể lấy mức tiêu thụ hiện tại thông qua các [phương pháp theo dõi tiêu thụ](https://reference.aspose.com/slides/vi/net/aspose.slides/metered/).

**Giấy phép tính theo mức tiêu thụ có phù hợp cho môi trường microservices và serverless, nơi các instance thường khởi động lại không?**

Có. Vì việc tính toán được thực hiện ở mức độ cuộc gọi API, nên các kịch bản có khởi động lạnh thường xuyên vẫn tương thích, với điều kiện có kết nối mạng ổn định để thực hiện các phép tính metered.

**Chức năng của thư viện có khác khi sử dụng giấy phép tính theo mức tiêu thụ so với giấy phép vĩnh viễn không?**

Không. Điều này chỉ liên quan đến cơ chế cấp phép và thanh toán; khả năng của sản phẩm vẫn như nhau.

**Giấy phép tính theo mức tiêu thụ liên quan như thế nào tới phiên bản dùng thử và giấy phép tạm thời?**

Phiên bản dùng thử có các hạn chế và watermark, [giấy phép tạm thời](https://purchase.aspose.com/temporary-license/) loại bỏ các hạn chế trong 30 ngày, và giấy phép tính theo mức tiêu thụ loại bỏ hạn chế và tính phí dựa trên mức sử dụng thực tế.

**Tôi có thể kiểm soát ngân sách bằng cách tự động phản hồi khi vượt ngưỡng tiêu thụ không?**

Có. Thực hành phổ biến là đọc định kỳ mức tiêu thụ hiện tại qua các [phương pháp theo dõi](https://reference.aspose.com/slides/vi/net/aspose.slides/metered/) và triển khai các giới hạn hoặc cảnh báo riêng của bạn ở mức ứng dụng hoặc giám sát.