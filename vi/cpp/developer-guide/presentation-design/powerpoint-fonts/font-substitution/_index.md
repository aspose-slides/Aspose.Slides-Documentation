---
title: Cấu hình thay thế phông chữ trong bản trình chiếu bằng С++
linktitle: Thay thế phông chữ
type: docs
weight: 70
url: /vi/cpp/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay phông chữ
- thay đổi phông chữ
- quy tắc thay thế
- quy tắc thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- С++
- Aspose.Slides
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho С++ khi chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang các định dạng file khác."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng phông chữ khác khi phông chữ gốc của bản trình chiếu không có sẵn trong quá trình render hoặc chuyển đổi. Bạn có thể kiểm tra các phông chữ nào đã được thay thế bằng cách sử dụng phương thức `GetSubstitutions` từ giao diện `IFontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không truy cập được sẽ được thay bằng một phông chữ khả dụng khác và sau đó áp dụng các quy tắc đó thông qua trình quản lý phông chữ của bản trình chiếu.

## **Đặt quy tắc thay thế phông chữ**

Aspose.Slides cho phép bạn thiết lập các quy tắc cho phông chữ xác định những gì phải thực hiện trong các điều kiện nhất định (ví dụ, khi không thể truy cập một phông chữ) theo cách sau:

1. Tải bản trình chiếu liên quan.
2. Tải phông chữ sẽ được thay thế.
3. Tải phông chữ mới.
4. Thêm một quy tắc cho việc thay thế.
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình chiếu.
6. Tạo hình ảnh slide để quan sát hiệu ứng.

Mã C++ dưới đây minh họa quy trình thay thế phông chữ:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Tải một bản trình chiếu
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Xác định phông chữ sẽ được thay thế và phông chữ mới
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Thêm quy tắc phông chữ cho việc thay thế phông chữ
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Thêm quy tắc vào bộ sưu tập các quy tắc thay thế phông chữ
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Thêm bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Lưu PPTX vào đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Bạn có thể muốn xem [**Font Replacement**](/slides/vi/cpp/font-replacement/). 
{{% /alert %}}

## **Các hạn chế đối với phông chữ công thức toán học**

Các quy tắc thay thế phông chữ tham gia vào quy trình chọn phông chữ tiêu chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng phù hợp cho các kịch bản văn bản thường, nơi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng một phông chữ khả dụng khác theo quy tắc đã cấu hình.

Tuy nhiên, các công thức toán học của Office có một hạn chế quan trọng. Nếu một công thức được tạo bằng **Cambria Math**, Aspose.Slides vẫn có thể yêu cầu phông chữ **Cambria Math** gốc để tính toán và render bố cục công thức một cách chính xác. Vì vậy, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn như **STIX Two Math**, không được hỗ trợ cho việc render công thức và có thể vẫn gây ra ngoại lệ chỉ ra rằng cần có **Cambria Math**.

Để chuyển đổi các bản trình chiếu như vậy thành công, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides tại thời gian chạy. Bạn có thể cài đặt phông chữ này trên hệ điều hành hoặc cung cấp nó như một [external font](/slides/vi/cpp/custom-font/) để nó tham gia vào quy trình chọn phông chữ bình thường trong quá trình render và chuyển đổi.

Hạn chế này chỉ áp dụng cho việc render công thức. Các quy tắc thay thế phông chữ tiêu chuẩn đã mô tả ở trên vẫn áp dụng cho văn bản trình chiếu thường khi phông chữ gốc không khả dụng.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế (substitution) phông chữ là gì?**  
[Replacement](/slides/vi/cpp/font-replacement/) là việc ép buộc thay thế một phông chữ bằng một phông chữ khác trên toàn bộ bản trình chiếu. Thay thế (substitution) là một quy tắc được kích hoạt trong một điều kiện cụ thể, ví dụ khi phông chữ gốc không khả dụng, và sau đó một phông chữ dự phòng được chỉ định sẽ được sử dụng.

**Khi nào các quy tắc thay thế được áp dụng?**  
Các quy tắc tham gia vào chuỗi [font selection](/slides/vi/cpp/font-selection-sequence/) tiêu chuẩn được đánh giá trong quá trình tải, render và chuyển đổi; nếu phông chữ được chọn không khả dụng, việc thay thế hoặc thay thế (substitution) sẽ được áp dụng.

**Hành vi mặc định là gì nếu không có cả thay thế nor substitution được cấu hình và phông chữ bị thiếu trên hệ thống?**  
Thư viện sẽ cố gắng chọn phông chữ hệ thống gần nhất có sẵn, giống như cách PowerPoint hoạt động.

**Tôi có thể đính kèm phông chữ tùy chỉnh bên ngoài ở thời gian chạy để tránh việc thay thế không?**  
Có. Bạn có thể [add external fonts](/slides/vi/cpp/custom-font/) ở thời gian chạy để thư viện xem xét chúng khi chọn và render, bao gồm cả các chuyển đổi tiếp theo.

**Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?**  
Không. Aspose không phân phối bất kỳ phông chữ nào, dù trả phí hay miễn phí; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác biệt nào trong hành vi thay thế trên Windows, Linux và macOS không?**  
Có. Việc khám phá phông bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ mặc định khả dụng và các đường dẫn tìm kiếm khác nhau giữa các nền tảng, điều này ảnh hưởng tới khả năng sẵn có và nhu cầu thay thế.

**Làm thế nào để tôi chuẩn bị môi trường nhằm giảm thiểu việc thay thế không mong muốn trong chuyển đổi hàng loạt?**  
Đồng bộ bộ phông chữ giữa các máy hoặc container, [add the external fonts](/slides/vi/cpp/custom-font/) cần thiết cho tài liệu đầu ra, và [embed fonts](/slides/vi/cpp/embedded-font/) trong bản trình chiếu khi có thể để các phông chữ đã chọn có sẵn trong quá trình render.