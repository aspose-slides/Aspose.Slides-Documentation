---
title: Quản lý các trường văn bản trong bài thuyết trình PowerPoint bằng .NET
linktitle: Các trường văn bản
type: docs
weight: 52
url: /vi/net/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- tiêu đề
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Tạo, kiểm tra, chỉnh sửa và xóa các trường văn bản trong bài thuyết trình PowerPoint bằng Aspose.Slides cho .NET. Bảo đảm định dạng và xác minh các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản gồm các phần. Một [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) thông thường chứa văn bản thuần; một phần trường cũng có một [IField](https://reference.aspose.com/slides/vi/net/aspose.slides/ifield/) mà kiểu xác định một giá trị được cập nhật tự động, chẳng hạn như số slide hoặc ngày. Hai phần có thể hiển thị cùng các ký tự trong khi chỉ một trong số chúng chứa trường.

Sử dụng [IPortion.Field](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/field/) để phân biệt chúng: nó sẽ là `null` đối với văn bản thông thường. [IPortion.AddField](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/addfield/) chuyển một phần hiện có thành trường. Giữ nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không đồng thời thay thế nhãn.

Hướng dẫn này đề cập đến các trường bên trong văn bản, cách định dạng chúng và lưu chúng trong PPTX và PPT. Đối với khung và đoạn văn bản, xem [Manage Text](/slides/vi/net/manage-text/).

## **Tạo Trường Số Slide**

Ví dụ đầy đủ dưới đây tạo một hộp văn bản chứa nhãn thuần `Slide ` và tiếp theo là một số được cập nhật tự động. Nó đặt kích thước, độ đậm và màu sắc của số trước khi thêm trường, sau đó mở lại bản trình bày đã lưu và kiểm tra kiểu trường, văn bản và định dạng. Không cần tệp đầu vào.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Bản trình bày mới bắt đầu với số slide là 1, vì vậy văn bản là `Slide 1`, và cả hai kiểm tra đều in ra `True`. Số này vẫn là một trường sau khi mở lại; nó không phải là một ký tự thuần `1`. Các phép chuyển đổi và chỉ mục trong quá trình xác minh đề cập đến hình dạng và các phần được tạo ra bởi ví dụ này.

## **Chọn Kiểu Trường**

[FieldType](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/) implements [IFieldType](https://reference.aspose.com/slides/vi/net/aspose.slides/ifieldtype/) và cung cấp các giá trị định trước sau. Gửi giá trị phù hợp tới [AddField](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/addfield/).

| Giá trị | Mục đích |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/slidenumber/) | Số slide hiện tại. |
| [DateTime](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/datetime/) | Ngày/giờ theo định dạng mặc định của ứng dụng render. |
| [DateTime1](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/datetime9/) | Các định dạng ngày hoặc ngày/giờ kết hợp đã được định trước. |
| [DateTime10](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/datetime13/) | Các định dạng thời gian đã được định trước, với tùy chọn cho giây và đồng hồ 12 giờ. |
| [Header](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/header/) | Trường tiêu đề; xem các giới hạn placeholder và định dạng bên dưới. |
| [Footer](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/footer/) | Trường chân trang. |

Ví dụ, [DateTime3](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/datetime3/) đại diện cho ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường đã được định trước, không phải chuỗi định dạng ngày .NET tùy ý. [LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/languageid/) của phần và ứng dụng xử lý bản trình bày có thể ảnh hưởng đến kết quả hiển thị.

## **Tạo Trường Từ Chuỗi Nội Bộ**

Phiên bản overload nhận chuỗi của [AddField](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/addfield/) chấp nhận một định danh trường nội bộ. Sử dụng nó khi muốn giữ lại một định danh được cung cấp bởi ứng dụng khác mà không có giá trị định trước. Bạn cũng có thể tạo một [FieldType](https://reference.aspose.com/slides/vi/net/aspose.slides/fieldtype/fieldtype/) từ định danh đó. [IFieldType.InternalString](https://reference.aspose.com/slides/vi/net/aspose.slides/ifieldtype/internalstring/) cung cấp định danh để kiểm tra.

Ví dụ này lưu một trường `custom-report-id` đặc thù của ứng dụng với văn bản dự phòng `Report-042`. Định danh không đăng ký phép tính: Aspose.Slides không tạo ID báo cáo cho kiểu không xác định. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Sau vòng quay PPTX này, kiểu là `custom-report-id` và văn bản là `Report-042`. Gửi một chuỗi như `yyyy-MM-dd` sẽ đặt tên cho một kiểu trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với ngày cố định ở định dạng tùy ý, hãy dùng văn bản thuần.

## **Kiểm Tra, Sửa Đổi và Xóa Trường Ngày/Giờ**

Đọc và thay đổi một trường hiện có qua [IField.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ifield/type/). Kiểm tra trường tồn tại trước khi truy cập kiểu của nó. Để dừng cập nhật tự động, gọi [IPortion.RemoveField](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/removefield/). Điều này giữ lại phần và văn bản hiện tại trong khi loại bỏ liên kết trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi xóa trường.

Đối với cài đặt API liên quan đến xử lý trường ngày/giờ, xem [Presentation.CurrentDateTime](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/currentdatetime/). Ví dụ dưới đây sử dụng ngày phê duyệt cụ thể khi chuyển trường thành văn bản thông thường.

Tải xuống [sample.pptx](sample.pptx) và đặt nó trong thư mục làm việc. Nó chứa hai hình dạng văn bản được đặt tên, `UpdatedAt` và `ApprovedDate`, mỗi hình có một trường ngày/giờ, cộng với các nhãn văn bản thuần. Ví dụ sau đây duyệt các hình dạng văn bản cấp cao trên các slide thông thường. Nó thay đổi các trường ngày/giờ sang định dạng ngày dài và làm chúng in nghiêng, đồng thời giữ các định dạng khác. Chỉ các trường trong `ApprovedDate` trở thành văn bản cố định.

Mẫu nhận diện các định danh nội bộ tích hợp `datetime` và `datetime1` tới `datetime13`. Các nhóm, bảng, ghi chú, bố cục và master yêu cầu duyệt các container văn bản riêng của chúng và nằm ngoài phạm vi của ví dụ này.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Sau khi mở lại, `UpdatedAt` có kiểu `datetime3` và vẫn động. `ApprovedDate` không có trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, cài đặt in đậm và màu sắc gốc vẫn giữ nguyên. Các nhãn văn bản thuần không thay đổi. Việc xác minh đọc phần đầu tiên của hai hình dạng đã biết trong mẫu được cung cấp.

## **Bảo Đảm Định Dạng Văn Bản**

Làm việc với phần hiện có khi thêm trường, thay đổi kiểu của nó hoặc xóa nó. Những thao tác này giữ lại định dạng của phần đó. Sử dụng [IPortion.PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/portionformat/) để thay đổi chỉ các thuộc tính cần thiết, như ví dụ làm màu hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc đó có thể làm mất ranh giới phần gốc và định dạng riêng của chúng. Ngoài ra, hãy phân biệt định dạng được đặt rõ ràng với định dạng thừa hưởng từ đoạn, bố cục hoặc chủ đề. Xem [Text Formatting](/slides/vi/net/text-formatting/) để biết các tùy chọn định dạng rộng hơn.

## **Trường và Placeholder Tiêu Đề/Chân Trang**

Một trường là một phần của đoạn văn bản. Một placeholder là một hình dạng có vai trò trong bản trình bày, chẳng hạn như chân trang hoặc số slide. Thêm trường vào một hộp văn bản thuần không biến hình dạng đó thành placeholder.

Các quản lý tiêu đề/chân trang kiểm soát văn bản và khả năng hiển thị của placeholder trên slide, bố cục và master, bao gồm việc lan truyền tới các slide phụ thuộc. Vì vậy, một trường số trong hộp văn bản tùy chỉnh vẫn hữu ích ngay cả khi bạn không sử dụng placeholder số slide. Ngược lại, việc thay đổi khả năng hiển thị của placeholder không loại bỏ trường khỏi một hộp văn bản không liên quan.

Các kiểu tiêu đề và chân trang đã định trước không tạo ra các placeholder tương ứng hoặc cung cấp nội dung của chúng. Đặc biệt, một slide PowerPoint thông thường không có placeholder tiêu đề; tiêu đề thuộc về trang ghi chú và tài liệu phát tay. Đừng giả định rằng một trường tiêu đề hoặc chân trang trong một hình dạng tùy ý sẽ tự động nhận được văn bản được cấu hình qua trình quản lý placeholder. Đối với quy trình đó, xem [Presentation Headers and Footers](/slides/vi/net/presentation-header-and-footer/).

## **Hạn Chế của PPTX và PPT**

Kiểm tra cả kiểu trường và văn bản kết quả sau khi lưu và mở lại. Giữ lại định danh không chứng minh rằng một ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định dạng | Hành vi và hạn chế của trường |
|---|---|
| PPTX | Lưu các định danh trường nội bộ cùng với văn bản trường. Trong các kiểm tra vòng quay, các kiểu đã định trước và định danh tùy chỉnh được sử dụng ở trên vẫn tồn tại sau khi lưu và mở lại. Kiểu tùy chỉnh không biết vẫn giữ văn bản dự phòng; nó không có logic tính tự động. Ứng dụng khác có thể xử lý các định danh không hỗ trợ khác nhau. |
| PPT | Sử dụng biểu diễn trường legacy và có tính tương thích hạn chế hơn. Trong các kiểm tra vòng quay, các trường số slide và trường ngày/giờ đã định trước vẫn tồn tại sau khi lưu và mở lại. Một trường tùy chỉnh trong hộp văn bản slide thông thường mở lại với định danh nhưng với `*` làm văn bản; một trường tiêu đề trong cùng ngữ cảnh cũng tạo ra `*`. Đừng dựa vào việc các trường tùy chỉnh hoặc ngữ cảnh trường không hỗ trợ giữ lại văn bản hiển thị. |

Đối với đầu ra cố định, di động, hãy chuyển các trường không hỗ trợ thành văn bản thuần và gán rõ ràng giá trị mong muốn trước khi lưu. Điều này giữ lại văn bản đã chọn nhưng cố ý dừng cập nhật tự động. Hãy kiểm tra ứng dụng đích cũng khi việc tính lại trường của nó là một phần trong quy trình làm việc của bạn.

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một số hoặc ngày hiển thị là trường hay không?**

Kiểm tra [IPortion.Field](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/field/). Giá trị không null cho biết có trường; chỉ nhìn vào văn bản hiển thị không đủ.

**Việc xóa một trường có xóa văn bản hoặc định dạng của nó không?**

Không. [RemoveField](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/removefield/) chuyển phần hiện có thành văn bản thuần. Gán giá trị cụ thể sau nếu bạn cần một ngày cố định hoặc văn bản dự phòng.

**Chuỗi nội bộ có thể định nghĩa định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một kiểu trường. Định danh không biết không cung cấp bộ đánh giá hay mẫu định dạng ngày .NET. Hãy dùng kiểu đã định trước hoặc định dạng giá trị dưới dạng văn bản thuần.

**Tại sao phải kiểm tra lại bản trình bày sau khi lưu?**

Các định danh trường, văn bản đã tính và định dạng là các khía cạnh riêng biệt cần xác minh. Chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay khi định danh trường vẫn còn.