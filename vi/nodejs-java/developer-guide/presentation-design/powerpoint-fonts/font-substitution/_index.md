---
title: Cấu hình Thay thế Phông chữ trong Bản trình bày sử dụng JavaScript
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/nodejs-java/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay đổi phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay thế
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho Node.js khi chuyển đổi các bản trình bày PowerPoint & OpenDocument sang các định dạng tệp khác trong JavaScript."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ khác khi phông chữ gốc của bản trình bày không khả dụng trong quá trình render hoặc chuyển đổi. Bạn có thể kiểm tra những phông chữ nào đã được thay thế bằng cách sử dụng phương thức `getSubstitutions` từ lớp `FontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không truy cập được sẽ được thay bằng một phông chữ có sẵn khác và sau đó áp dụng các quy tắc này thông qua font manager của bản trình bày.

## **Đặt quy tắc thay thế phông chữ**

Aspose.Slides cho phép bạn đặt các quy tắc cho phông chữ để xác định những gì cần thực hiện trong một số điều kiện (ví dụ, khi một phông chữ không thể truy cập) như sau:

1. Tải bản trình bày liên quan.
2. Tải phông chữ sẽ được thay thế.
3. Tải phông chữ mới.
4. Thêm một quy tắc cho việc thay thế.
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình bày.
6. Tạo ảnh slide để quan sát hiệu quả.

Mã JavaScript này minh họa quy trình thay thế phông chữ:

```javascript
// Tải một bản trình bày
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Tải phông chữ nguồn sẽ được thay thế
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Tải phông chữ mới
    var destFont = new aspose.slides.FontData("Arial");
    // Thêm một quy tắc phông chữ cho việc thay thế
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Thêm quy tắc vào bộ sưu tập các quy tắc thay thế phông chữ
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Thêm bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Phông chữ Arial sẽ được sử dụng thay cho SomeRareFont khi phông chữ này không khả dụng
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Lưu hình ảnh ra đĩa ở định dạng JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Bạn có thể muốn xem [**Thay thế phông chữ**](/slides/vi/nodejs-java/font-replacement/).

{{% /alert %}}

## **Hạn chế đối với phông chữ phương trình Toán học**

Các quy tắc thay thế phông chữ tham gia vào quy trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng phù hợp cho các trường hợp văn bản thường, nơi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng một phông chữ có sẵn khác theo quy tắc đã cấu hình.

Tuy nhiên, các phương trình toán học của Office có một hạn chế quan trọng. Nếu một phương trình được tạo bằng **Cambria Math**, Aspose.Slides vẫn có thể yêu cầu phông chữ gốc **Cambria Math** để tính toán và render bố cục phương trình một cách chính xác. Do đó, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không được hỗ trợ cho việc render phương trình và có thể vẫn gây ra ngoại lệ cho biết **Cambria Math** là cần thiết.

Để chuyển đổi thành công các bản trình bày như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides tại thời gian chạy. Bạn có thể cài đặt phông chữ này trong hệ điều hành hoặc cung cấp nó như một [phông chữ bên ngoài](/slides/vi/nodejs-java/custom-font/) để nó có thể tham gia vào quy trình lựa chọn phông chữ bình thường trong quá trình render và chuyển đổi.

Hạn chế này chỉ áp dụng cho việc render phương trình. Các quy tắc thay thế phông chữ tiêu chuẩn đã mô tả ở trên vẫn áp dụng cho văn bản thông thường của bản trình bày khi phông chữ gốc không khả dụng.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế (substitution) phông chữ?**

[Replacement](/slides/vi/nodejs-java/font-replacement/) là việc ép buộc thay thế một phông chữ bằng phông chữ khác trên toàn bộ bản trình bày. Thay thế (substitution) là một quy tắc được kích hoạt khi có một điều kiện cụ thể, ví dụ khi phông chữ gốc không khả dụng, và sau đó một phông chữ dự phòng được chỉ định sẽ được sử dụng.

**Khi nào các quy tắc thay thế (substitution) được áp dụng?**

Các quy tắc tham gia vào chuỗi [font selection](/slides/vi/nodejs-java/font-selection-sequence/) tiêu chuẩn được đánh giá trong quá trình tải, render và chuyển đổi; nếu phông chữ được chọn không khả dụng, việc thay thế hoặc thay thế (substitution) sẽ được áp dụng.

**Hành vi mặc định là gì nếu không có cả thay thế và thay thế (substitution) nào được cấu hình và phông chữ không tồn tại trên hệ thống?**

Thư viện sẽ cố gắng chọn phông chữ hệ thống gần nhất có sẵn, tương tự như cách PowerPoint hoạt động.

**Tôi có thể đính kèm phông chữ bên ngoài tùy chỉnh tại thời gian chạy để tránh việc thay thế không?**

Có. Bạn có thể [add external fonts](/slides/vi/nodejs-java/custom-font/) tại thời gian chạy để thư viện xem xét chúng cho việc lựa chọn và render, bao gồm cả các chuyển đổi tiếp theo.

**Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?**

Không. Aspose không phân phối bất kỳ phông chữ trả phí hay miễn phí nào; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác biệt nào trong hành vi thay thế trên Windows, Linux và macOS không?**

Có. Việc khám phá phông chữ bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ mặc định có sẵn và các đường dẫn tìm kiếm khác nhau giữa các nền tảng, điều này ảnh hưởng đến tính sẵn có và nhu cầu thay thế.

**Làm thế nào để chuẩn bị môi trường nhằm giảm thiểu việc thay thế không mong muốn trong quá trình chuyển đổi hàng loạt?**

Đồng bộ bộ phông chữ trên các máy hoặc container, [add the external fonts](/slides/vi/nodejs-java/custom-font/) cần thiết cho các tài liệu đầu ra, và [embed fonts](/slides/vi/nodejs-java/embedded-font/) trong bản trình bày khi có thể để các phông chữ được chọn có sẵn trong quá trình render.