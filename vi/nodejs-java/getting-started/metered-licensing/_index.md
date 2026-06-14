---
title: Giấy phép đo lường
type: docs
weight: 100
url: /vi/nodejs-java/metered-licensing/
keywords:
- giấy phép
- giấy phép đo lường
- khóa giấy phép
- khóa công khai
- khóa riêng
- số lượng tiêu thụ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides cho Node.js qua Java với giấy phép đo lường cho phép bạn xử lý các tệp PowerPoint và OpenDocument một cách linh hoạt, chỉ trả tiền cho những gì bạn sử dụng."
---
## **Giới thiệu**

Giấy phép đo lường (Metered licensing) là một cơ chế cấp phép có thể được sử dụng song song với các phương pháp cấp phép hiện có. Nếu bạn muốn được tính phí dựa trên mức độ sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép đo lường.

## **Áp dụng Khóa Metered**

Khi bạn mua một giấy phép đo lường, bạn sẽ nhận được các khóa (không có tệp giấy phép). Khóa đo lường này có thể được áp dụng bằng lớp [Metered](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/metered/) mà Aspose cung cấp cho các hoạt động đo lường. Để biết thêm chi tiết, xem [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Tạo một thể hiện của lớp [Metered](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/metered/).

1. Gọi phương thức [setMeteredKey](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/metered/#setMeteredKey) và truyền khóa công cộng và khóa riêng của bạn.

1. Thực hiện một số xử lý (thực hiện các tác vụ).

1. Gọi phương thức [getConsumptionQuantity](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) của lớp `Metered`.

Bạn sẽ thấy số lượng/yêu cầu API mà bạn đã tiêu thụ cho tới hiện tại.

Đoạn mã mẫu dưới đây cho thấy cách sử dụng giấy phép đo lường:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tạo một thể hiện của lớp Metered
var metered = new aspose.slides.Metered();

// Truyền khóa công khai và khóa riêng cho đối tượng Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Lấy giá trị lượng tiêu thụ trước các lời gọi API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Thực hiện một số thao tác với API Aspose.Slides ở đây
// ...

// Lấy giá trị lượng tiêu thụ sau các lời gọi API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
Để sử dụng giấy phép đo lường, bạn cần một kết nối internet ổn định vì cơ chế cấp phép sử dụng internet để liên tục tương tác với dịch vụ của chúng tôi và thực hiện các phép tính.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng giấy phép đo lường cùng với giấy phép thông thường (vĩnh viễn hoặc tạm thời) trong cùng một ứng dụng không?**

Có. Metered là một cơ chế cấp phép bổ sung có thể được sử dụng song song với các [phương pháp cấp phép](/slides/vi/nodejs-java/licensing/) hiện có. Bạn chọn cơ chế nào sẽ áp dụng khi ứng dụng khởi động.

**Cụ thể những gì được tính là tiêu thụ trong giấy phép đo lường: các hoạt động hay các tệp?**

Việc sử dụng API được tính, nghĩa là số lượng yêu cầu hoặc hoạt động. Bạn có thể lấy mức tiêu thụ hiện tại thông qua các [phương pháp theo dõi tiêu thụ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/metered/).

**Giấy phép đo lường có phù hợp với môi trường microservice và serverless, nơi các thực thể thường khởi động lại không?**

Có. Vì việc tính toán được thực hiện ở mức gọi API, các kịch bản có khởi động lạnh thường xuyên vẫn tương thích, với điều kiện có kết nối mạng ổn định cho các phép tính đo lường.

**Chức năng của thư viện có khác khi sử dụng giấy phép đo lường so với giấy phép vĩnh viễn không?**

Không. Điều này chỉ liên quan đến cơ chế cấp phép và tính phí; khả năng của sản phẩm vẫn giống nhau.

**Giấy phép đo lường liên quan như thế nào đến phiên bản dùng thử và giấy phép tạm thời?**

Phiên bản dùng thử có các hạn chế và dấu bản quyền, [giấy phép tạm thời](https://purchase.aspose.com/temporary-license/) loại bỏ các hạn chế trong 30 ngày, và giấy phép đo lường loại bỏ hạn chế và tính phí dựa trên mức sử dụng thực tế.

**Tôi có thể kiểm soát ngân sách bằng cách tự động phản hồi khi vượt quá ngưỡng tiêu thụ không?**

Có. Một thực hành phổ biến là định kỳ đọc mức tiêu thụ hiện tại qua các [phương pháp theo dõi](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/metered/) và triển khai các giới hạn hoặc cảnh báo riêng tại mức ứng dụng hoặc hệ thống giám sát.