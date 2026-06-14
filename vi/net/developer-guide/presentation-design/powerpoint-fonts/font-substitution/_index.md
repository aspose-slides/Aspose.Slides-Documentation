---
title: Cấu hình Thay thế Phông chữ trong Bản trình bày trên .NET
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho .NET khi chuyển đổi các bản trình bày PowerPoint & OpenDocument sang các định dạng tệp khác."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ khác khi phông chữ gốc của bản trình bày không khả dụng trong quá trình hiển thị hoặc chuyển đổi. Bạn có thể kiểm tra các phông chữ đã được thay thế bằng cách sử dụng phương thức `GetSubstitutions` từ giao diện `IFontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không truy cập được sẽ được thay bằng một phông chữ khả dụng khác và sau đó áp dụng các quy tắc đó thông qua trình quản lý phông chữ của bản trình bày.

## **Lấy các Thay thế Phông chữ**

Để giúp bạn tìm ra các phông chữ trong bản trình bày đã được thay thế trong quá trình hiển thị bản trình bày, Aspose.Slides cung cấp phương thức [GetSubstitution](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getsubstitutions/) từ giao diện [IFontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/).

Mã C# cho thấy cách lấy tất cả các thay thế phông chữ được thực hiện khi một bản trình bày được hiển thị:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Đặt Quy tắc Thay thế Phông chữ**

Aspose.Slides cho phép bạn đặt các quy tắc cho phông chữ nhằm xác định những gì phải thực hiện trong các điều kiện nhất định (ví dụ, khi một phông chữ không thể truy cập) theo cách sau:

1. Tải bản trình bày liên quan.  
2. Tải phông chữ sẽ được thay thế.  
3. Tải phông chữ mới.  
4. Thêm một quy tắc cho việc thay thế.  
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình bày.  
6. Tạo hình ảnh slide để quan sát hiệu quả.

Mã C# này minh họa quy trình thay thế phông chữ:
```c#
// Tải bản trình bày
Presentation presentation = new Presentation("Fonts.pptx");

// Tải phông chữ nguồn sẽ được thay thế
IFontData sourceFont = new FontData("SomeRareFont");

// Tải phông chữ mới
IFontData destFont = new FontData("Arial");

// Thêm quy tắc phông chữ cho việc thay thế phông chữ
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Thêm bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Lưu ảnh vào đĩa ở định dạng JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Bạn có thể muốn xem [**Thay thế Phông chữ**](/slides/vi/net/font-replacement/). 
{{% /alert %}}

## **Giới hạn cho Phông chữ Phương trình Toán học**

Các quy tắc thay thế phông chữ tham gia vào quá trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình hiển thị và chuyển đổi. Chúng phù hợp cho các kịch bản văn bản thông thường, nơi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng một phông chữ khả dụng khác theo quy tắc đã cấu hình.

Tuy nhiên, các phương trình toán học của Office có một giới hạn quan trọng. Nếu một phương trình được tạo bằng **Cambria Math**, Aspose.Slides vẫn có thể yêu cầu phông chữ **Cambria Math** gốc để tính toán và hiển thị bố cục phương trình một cách chính xác. Vì vậy, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không được hỗ trợ cho việc hiển thị phương trình và có thể vẫn gây ra ngoại lệ cho biết **Cambria Math** là bắt buộc.

Để chuyển đổi các bản trình bày như vậy một cách thành công, hãy đảm bảo rằng **Cambria Math** có sẵn cho Aspose.Slides tại thời gian chạy. Bạn có thể cài đặt phông chữ này trong hệ điều hành hoặc cung cấp nó dưới dạng một [phông chữ bên ngoài](/slides/vi/net/custom-font/) để nó có thể tham gia vào quá trình lựa chọn phông chữ bình thường trong quá trình hiển thị và chuyển đổi.

Giới hạn này chỉ áp dụng cho việc hiển thị phương trình. Các quy tắc thay thế phông chữ tiêu chuẩn được mô tả ở trên vẫn áp dụng cho văn bản bản trình bày thông thường khi phông chữ gốc không khả dụng.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế (substitution) phông chữ là gì?**  
[Thay thế](/slides/vi/net/font-replacement/) là việc buộc ghi đè một phông chữ bằng phông chữ khác trên toàn bộ bản trình bày. Thay thế (substitution) là một quy tắc được kích hoạt dưới một điều kiện cụ thể, ví dụ khi phông chữ gốc không có sẵn, và sau đó một phông chữ dự phòng được sử dụng.

**Khi nào các quy tắc thay thế được áp dụng?**  
Các quy tắc tham gia vào chuỗi [lựa chọn phông chữ](/slides/vi/net/font-selection-sequence/) tiêu chuẩn được đánh giá trong quá trình tải, hiển thị và chuyển đổi; nếu phông chữ được chọn không khả dụng, việc thay thế hoặc thay thế (substitution) sẽ được áp dụng.

**Hành vi mặc định nếu không có quy tắc thay thế hay thay thế nào được cấu hình và phông chữ thiếu trên hệ thống là gì?**  
Thư viện sẽ cố gắng chọn phông chữ hệ thống khả dụng gần nhất, tương tự như cách PowerPoint sẽ hành xử.

**Tôi có thể đính kèm phông chữ bên ngoài tùy chỉnh tại thời gian chạy để tránh việc thay thế không?**  
Có. Bạn có thể [thêm phông chữ bên ngoài](/slides/vi/net/custom-font/) tại thời gian chạy để thư viện cân nhắc chúng cho việc lựa chọn và hiển thị, bao gồm cả các chuyển đổi tiếp theo.

**Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?**  
Không. Aspose không phân phối phông chữ trả phí hay miễn phí; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác biệt nào trong hành vi thay thế giữa Windows, Linux và macOS không?**  
Có. Quá trình khám phá phông chữ bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ khả dụng mặc định và các đường dẫn tìm kiếm khác nhau trên các nền tảng, ảnh hưởng đến tính khả dụng và nhu cầu thay thế.

**Làm thế nào để chuẩn bị môi trường nhằm giảm thiểu việc thay thế bất ngờ trong chuyển đổi hàng loạt?**  
Đồng bộ bộ phông chữ giữa các máy hoặc container, [thêm các phông chữ bên ngoài](/slides/vi/net/custom-font/) cần thiết cho tài liệu đầu ra, và [nhúng phông chữ](/slides/vi/net/embedded-font/) trong bản trình bày khi có thể để các phông chữ đã chọn có sẵn trong quá trình hiển thị.