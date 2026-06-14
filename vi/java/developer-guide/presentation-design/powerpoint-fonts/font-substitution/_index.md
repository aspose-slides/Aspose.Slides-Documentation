---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu Sử dụng Java
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/java/font-substitution/
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho Java khi chuyển đổi bản trình chiếu PowerPoint & OpenDocument sang các định dạng tệp khác."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ khác khi phông chữ gốc của bản trình chiếu không khả dụng trong quá trình render hoặc chuyển đổi. Bạn có thể kiểm tra các phông chữ đã được thay thế bằng cách sử dụng phương thức `getSubstitutions` của giao diện `IFontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không truy cập được nên được thay bằng một phông chữ khả dụng khác và sau đó áp dụng các quy tắc này thông qua trình quản lý phông chữ của bản trình chiếu.

## **Đặt quy tắc thay thế phông chữ**

Aspose.Slides cho phép bạn đặt các quy tắc cho phông chữ, xác định những việc cần thực hiện trong một số điều kiện nhất định (ví dụ, khi không thể truy cập một phông chữ) như sau:

1. Tải bản trình chiếu liên quan.
2. Tải phông chữ sẽ được thay thế.
3. Tải phông chữ mới.
4- Thêm một quy tắc cho việc thay thế.
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình chiếu.
6. Tạo hình ảnh slide để quan sát hiệu quả.

Mã Java này minh họa quy trình thay thế phông chữ:

```java
// Tải một bản trình chiếu
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Tải phông chữ nguồn sẽ được thay thế
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Tải phông chữ mới
    IFontData destFont = new FontData("Arial");
    
    // Thêm quy tắc phông chữ cho việc thay thế phông chữ
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Thêm bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Phông chữ Arial sẽ được sử dụng thay cho SomeRareFont khi phông chữ này không truy cập được
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Lưu hình ảnh vào đĩa ở định dạng JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Bạn có thể muốn xem [**Font Replacement**](/slides/vi/java/font-replacement/). 
{{% /alert %}}

## **Hạn chế đối với phông chữ công thức toán học**

Các quy tắc thay thế phông chữ tham gia vào quy trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng phù hợp cho các trường hợp văn bản thông thường, nơi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng một phông chữ khả dụng khác theo quy tắc đã cấu hình.

Tuy nhiên, các công thức toán học của Office có một hạn chế quan trọng. Nếu một công thức được tạo bằng **Cambria Math**, Aspose.Slides có thể vẫn cần phông chữ **Cambria Math** gốc để tính toán và render bố cục công thức một cách chính xác. Do đó, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không được hỗ trợ cho việc render công thức và có thể vẫn gây ra ngoại lệ cho biết **Cambria Math** là bắt buộc.

Để chuyển đổi các bản trình chiếu như vậy một cách thành công, hãy đảm bảo rằng **Cambria Math** có sẵn cho Aspose.Slides trong thời gian chạy. Bạn có thể cài đặt phông chữ này trên hệ điều hành hoặc cung cấp nó dưới dạng một [external font](/slides/vi/java/custom-font/) để nó có thể tham gia vào quy trình lựa chọn phông chữ bình thường trong quá trình render và chuyển đổi.

Hạn chế này chỉ áp dụng cho việc render công thức. Các quy tắc thay thế phông chữ tiêu chuẩn mô tả ở trên vẫn áp dụng cho văn bản thường trong bản trình chiếu khi phông chữ gốc không khả dụng.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa việc thay thế phông chữ và thay thế phông chữ?**

[Replacement](/slides/vi/java/font-replacement/) là một việc ghi đè bắt buộc một phông chữ bằng phông chữ khác trên toàn bộ bản trình chiếu. Thay thế (substitution) là một quy tắc được kích hoạt dưới một điều kiện cụ thể, ví dụ khi phông chữ gốc không khả dụng, và sau đó một phông chữ dự phòng được chỉ định sẽ được sử dụng.

**Khi nào các quy tắc thay thế (substitution) được áp dụng?**

Các quy tắc tham gia vào chuỗi [font selection](/slides/vi/java/font-selection-sequence/) tiêu chuẩn được đánh giá trong quá trình tải, render và chuyển đổi; nếu phông chữ được chọn không khả dụng, việc thay thế hoặc thay thế (substitution) sẽ được áp dụng.

**Hành vi mặc định là gì nếu không có quy tắc thay thế hay substitution nào được cấu hình và phông chữ thiếu trên hệ thống?**

Thư viện sẽ cố gắng chọn phông chữ hệ thống khả dụng gần nhất, tương tự như cách PowerPoint hoạt động.

**Tôi có thể đính kèm phông chữ tùy chỉnh bên ngoài tại thời gian chạy để tránh substitution không?**

Có. Bạn có thể [add external fonts](/slides/vi/java/custom-font/) tại thời gian chạy để thư viện cân nhắc chúng cho việc lựa chọn và render, bao gồm cả các chuyển đổi tiếp theo.

**Aspose có phân phối bất kỳ phông chữ nào đi kèm với thư viện không?**

Không. Aspose không phân phối phông chữ trả phí hay miễn phí; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác biệt nào trong hành vi substitution trên Windows, Linux và macOS không?**

Có. Quá trình phát hiện phông chữ bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ khả dụng mặc định và các đường dẫn tìm kiếm khác nhau giữa các nền tảng, điều này ảnh hưởng đến khả năng sẵn có và nhu cầu thay thế.

**Làm thế nào để chuẩn bị môi trường nhằm giảm thiểu substitution không mong muốn trong các chuyển đổi hàng loạt?**

Đồng bộ bộ phông chữ giữa các máy hoặc container, [add the external fonts](/slides/vi/java/custom-font/) cần thiết cho các tài liệu đầu ra, và [embed fonts](/slides/vi/java/embedded-font/) trong bản trình chiếu khi có thể để các phông chữ đã chọn có sẵn trong quá trình render.