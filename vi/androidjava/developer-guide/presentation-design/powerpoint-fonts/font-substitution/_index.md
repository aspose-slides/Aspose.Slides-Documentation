---
title: "Cấu hình Thay thế Phông chữ trong các Bản trình bày trên Android"
linktitle: "Thay thế Phông chữ"
type: docs
weight: 70
url: /vi/androidjava/font-substitution/
keywords:
- "phông chữ"
- "thay thế phông chữ"
- "thay thế phông chữ"
- "thay thế phông chữ"
- "thay thế phông chữ"
- "quy tắc thay thế"
- "quy tắc thay thế"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho Android qua Java khi chuyển đổi các bản trình bày PowerPoint & OpenDocument sang các định dạng tệp khác."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ khác khi phông chữ gốc của bản trình bày không khả dụng trong quá trình hiển thị hoặc chuyển đổi. Bạn có thể kiểm tra những phông chữ nào đã được thay thế bằng cách sử dụng phương thức `getSubstitutions` từ giao diện `IFontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không thể truy cập sẽ được thay thế bằng một phông chữ khả dụng khác và sau đó áp dụng các quy tắc đó thông qua bộ quản lý phông chữ của bản trình bày.

## **Đặt quy tắc thay thế phông chữ**

Aspose.Slides cho phép bạn đặt các quy tắc cho phông chữ xác định những gì cần thực hiện trong các điều kiện nhất định (ví dụ, khi một phông chữ không thể truy cập) theo cách sau:

1. Tải bản trình bày liên quan.
2. Tải phông chữ sẽ được thay thế.
3. Tải phông chữ mới.
4. Thêm một quy tắc cho việc thay thế.
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình bày.
6. Tạo hình ảnh slide để quan sát hiệu quả.

Đoạn mã Java này minh họa quá trình thay thế phông chữ:

```java
// Tải một bản trình bày
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Tải phông chữ nguồn sẽ được thay thế
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Tải phông chữ mới
    IFontData destFont = new FontData("Arial");
    
    // Thêm một quy tắc phông chữ cho việc thay thế phông chữ
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Thêm bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Phông chữ Arial sẽ được sử dụng thay cho SomeRareFont khi phông chữ này không khả dụng
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
Bạn có thể muốn xem [**Thay thế phông chữ**](/slides/vi/androidjava/font-replacement/).
{{% /alert %}}

## **Giới hạn cho phông chữ công thức toán học**

Các quy tắc thay thế phông chữ tham gia vào quá trình chọn phông chữ tiêu chuẩn được sử dụng trong quá trình hiển thị và chuyển đổi. Chúng phù hợp cho các trường hợp văn bản thông thường, nơi Aspose.Slides có thể thay thế một phông chữ không khả dụng bằng một phông chữ khả dụng khác theo quy tắc đã cấu hình.

Tuy nhiên, các công thức toán học của Office có một hạn chế quan trọng. Nếu một công thức được tạo bằng **Cambria Math**, Aspose.Slides vẫn có thể yêu cầu phông chữ **Cambria Math** gốc để tính toán và hiển thị bố cục công thức một cách chính xác. Do đó, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn như **STIX Two Math**, không được hỗ trợ cho việc hiển thị công thức và vẫn có thể dẫn đến ngoại lệ báo rằng cần có **Cambria Math**.

Để chuyển đổi các bản trình bày như vậy một cách thành công, hãy chắc chắn rằng **Cambria Math** có sẵn cho Aspose.Slides khi chạy. Bạn có thể cài đặt phông chữ này trong hệ điều hành hoặc cung cấp nó như một [phông chữ bên ngoài](/slides/vi/androidjava/custom-font/) để nó có thể tham gia vào quá trình chọn phông chữ bình thường trong quá trình hiển thị và chuyển đổi.

Hạn chế này chỉ áp dụng cho việc hiển thị công thức. Các quy tắc thay thế phông chữ tiêu chuẩn được mô tả ở trên vẫn áp dụng cho văn bản bình thường của bản trình bày khi phông chữ gốc không khả dụng.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa việc thay thế phông chữ và việc thay thế (substitution) phông chữ là gì?**

[Replacement](/slides/vi/androidjava/font-replacement/) là việc ép buộc ghi đè một phông chữ bằng một phông chữ khác trên toàn bộ bản trình bày. Thay thế (substitution) là một quy tắc được kích hoạt trong một điều kiện cụ thể, ví dụ khi phông chữ gốc không có sẵn, và sau đó một phông chữ dự phòng được chỉ định sẽ được sử dụng.

**Khi nào các quy tắc thay thế (substitution) được áp dụng chính xác?**

Các quy tắc tham gia vào chuỗi [font selection](/slides/vi/androidjava/font-selection-sequence/) tiêu chuẩn được đánh giá trong quá trình tải, hiển thị và chuyển đổi; nếu phông chữ đã chọn không khả dụng, việc thay thế hoặc thay thế (substitution) sẽ được áp dụng.

**Hành vi mặc định là gì nếu không có cả thay thế (replacement) nor thay thế (substitution) nào được cấu hình và phông chữ thiếu trên hệ thống?**

Thư viện sẽ cố gắng chọn phông chữ hệ thống gần nhất có sẵn, tương tự như cách PowerPoint hoạt động.

**Tôi có thể đính kèm phông chữ bên ngoài tùy chỉnh tại thời gian chạy để tránh việc thay thế không?**

Có. Bạn có thể [thêm phông chữ bên ngoài](/slides/vi/androidjava/custom-font/) tại thời gian chạy để thư viện xem xét chúng cho việc lựa chọn và hiển thị, bao gồm cả cho các chuyển đổi tiếp theo.

**Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?**

Không. Aspose không phân phối bất kỳ phông chữ trả phí hay miễn phí nào; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác biệt nào trong hành vi thay thế (substitution) trên Windows, Linux và macOS không?**

Có. Quá trình tìm kiếm phông chữ bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ khả dụng mặc định và các đường dẫn tìm kiếm khác nhau giữa các nền tảng, điều này ảnh hưởng đến khả năng sẵn có và nhu cầu thay thế.

**Tôi nên chuẩn bị môi trường như thế nào để giảm thiểu việc thay thế không mong muốn trong quá trình chuyển đổi hàng loạt?**

Đồng bộ bộ phông chữ trên các máy hoặc container, [thêm phông chữ bên ngoài](/slides/vi/androidjava/custom-font/) cần thiết cho tài liệu đầu ra, và [nhúng phông chữ](/slides/vi/androidjava/embedded-font/) vào bản trình bày khi có thể để các phông chữ đã chọn có sẵn trong quá trình hiển thị.