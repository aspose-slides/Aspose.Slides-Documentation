---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu bằng C++
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho C++ khi chuyển đổi các bản trình chiếu PowerPoint & OpenDocument sang các định dạng tệp khác."
---
## **Tổng quan**

Việc thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ khác khi phông chữ gốc của bản trình chiếu không có sẵn trong quá trình hiển thị hoặc chuyển đổi. Bạn có thể kiểm tra các phông chữ đã được thay thế bằng cách sử dụng phương thức `GetSubstitutions` từ giao diện `IFontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không truy cập được sẽ được thay bằng một phông chữ khả dụng khác và sau đó áp dụng các quy tắc đó thông qua trình quản lý phông chữ của bản trình chiếu.

## **Đặt quy tắc thay thế phông chữ**

Aspose.Slides cho phép bạn đặt các quy tắc cho phông chữ xác định những gì phải làm trong một số điều kiện (ví dụ, khi không thể truy cập một phông chữ) như sau:

1. Tải bản trình chiếu liên quan.  
2. Tải phông chữ sẽ được thay thế.  
3. Tải phông chữ mới.  
4. Thêm quy tắc cho việc thay thế.  
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình chiếu.  
6. Tạo hình ảnh slide để quan sát kết quả.

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
	
// Thêm một quy tắc phông chữ cho việc thay thế phông chữ
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Thêm bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Lưu PPTX vào đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Bạn có thể muốn xem [**Thay thế Phông chữ**](/slides/vi/cpp/font-replacement/). 
{{% /alert %}}

## **Giới hạn cho phông chữ công thức Toán học**

Các quy tắc thay thế phông chữ tham gia vào quy trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình hiển thị và chuyển đổi. Chúng phù hợp cho các trường hợp văn bản thông thường, nơi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng một phông chữ khả dụng khác theo quy tắc đã cấu hình.

Tuy nhiên, các công thức Toán học của Office có một hạn chế quan trọng. Nếu một công thức được tạo bằng **Cambria Math**, Aspose.Slides vẫn có thể yêu cầu phông chữ **Cambria Math** gốc để tính toán và hiển thị bố cục công thức một cách chính xác. Vì vậy, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không được hỗ trợ cho việc hiển thị công thức và có thể vẫn gây ra ngoại lệ chỉ ra rằng **Cambria Math** là bắt buộc.

Để chuyển đổi các bản trình chiếu như vậy một cách thành công, hãy đảm bảo rằng **Cambria Math** có sẵn cho Aspose.Slides ở thời gian chạy. Bạn có thể cài đặt phông chữ này trên hệ điều hành hoặc cung cấp nó như một [phông chữ bên ngoài](/slides/vi/cpp/custom-font/) để nó tham gia vào quy trình lựa chọn phông chữ thông thường trong quá trình hiển thị và chuyển đổi.

Hạn chế này chỉ áp dụng cho việc hiển thị công thức. Các quy tắc thay thế phông chữ tiêu chuẩn được mô tả ở trên vẫn áp dụng cho văn bản thường của bản trình chiếu khi phông chữ gốc không khả dụng.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế (substitution) phông chữ là gì?**

[Thay thế](/slides/vi/cpp/font-replacement/) là việc buộc ghi đè một phông chữ bằng phông chữ khác trên toàn bộ bản trình chiếu. Thay thế (substitution) là một quy tắc được kích hoạt trong một điều kiện cụ thể, ví dụ khi phông chữ gốc không có sẵn, và sau đó một phông chữ dự phòng được sử dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào chuỗi [lựa chọn phông chữ](/slides/vi/cpp/font-selection-sequence/) tiêu chuẩn được đánh giá trong quá trình tải, hiển thị và chuyển đổi; nếu phông chữ đã chọn không khả dụng, việc thay thế hoặc thay thế (substitution) sẽ được thực hiện.

**Hành vi mặc định nếu không có quy tắc thay thế hoặc thay thế (substitution) nào được cấu hình và phông chữ thiếu trên hệ thống là gì?**

Thư viện sẽ cố gắng chọn phông chữ hệ thống khả dụng gần nhất, tương tự như cách PowerPoint sẽ hành xử.

**Tôi có thể đính kèm phông chữ bên ngoài tùy chỉnh tại thời gian chạy để tránh việc thay thế không mong muốn không?**

Có. Bạn có thể [thêm phông chữ bên ngoài](/slides/vi/cpp/custom-font/) tại thời gian chạy để thư viện xem xét chúng trong quá trình lựa chọn và hiển thị, bao gồm cả các lần chuyển đổi sau này.

**Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?**

Không. Aspose không phân phối phông chữ trả phí hay miễn phí; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác biệt trong hành vi thay thế trên Windows, Linux và macOS không?**

Có. Quá trình khám phá phông chữ bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ khả dụng mặc định và các đường dẫn tìm kiếm khác nhau giữa các nền tảng, ảnh hưởng đến tính khả dụng và nhu cầu thay thế.

**Tôi nên chuẩn bị môi trường như thế nào để giảm thiểu việc thay thế không mong muốn trong các chuyển đổi hàng loạt?**

Đồng bộ bộ phông chữ trên các máy hoặc container, [thêm các phông chữ bên ngoài](/slides/vi/cpp/custom-font/) cần thiết cho các tài liệu đầu ra, và [nhúng phông chữ](/slides/vi/cpp/embedded-font/) vào bản trình chiếu khi có thể để các phông chữ đã chọn có sẵn trong quá trình hiển thị.