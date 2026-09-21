---
title: Quản lý các trường văn bản trong bài thuyết trình PowerPoint bằng JavaScript
linktitle: Trường Văn bản
type: docs
weight: 52
url: /vi/nodejs-java/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- đầu trang
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo, kiểm tra, sửa đổi và xóa các trường văn bản trong bài thuyết trình PowerPoint với Aspose.Slides cho Node.js qua Java. Bảo tồn định dạng và xác minh các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản gồm các phần. Một [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) thông thường chứa văn bản nguyên mẫu; một phần trường còn có một [Field](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/field/) mà loại của nó xác định một giá trị được cập nhật tự động, chẳng hạn như số slide hoặc ngày tháng. Hai phần có thể hiển thị cùng ký tự trong khi chỉ có một trong số chúng chứa trường.

Sử dụng [Portion.getField](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#getField) để phân biệt chúng: nó trả về `null` đối với văn bản thông thường. [Portion.addField](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#addField) chuyển một phần hiện có thành trường. Giữ nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không đồng thời thay thế nhãn.

Hướng dẫn này đề cập đến các trường trong văn bản, cách định dạng chúng và lưu chúng trong PPTX và PPT. Đối với khung văn bản và đoạn văn, xem [Manage Text](/slides/vi/nodejs-java/manage-text/).

## **Tạo Trường Số Slide**

Ví dụ đầy đủ dưới đây tạo một hộp văn bản chứa nhãn nguyên mẫu `Slide ` tiếp theo là một số được cập nhật tự động. Nó đặt kích thước, độ đậm và màu sắc của số trước khi thêm trường, sau đó mở lại bản trình chiếu đã lưu và kiểm tra loại trường, văn bản và định dạng. Không cần tệp đầu vào.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Bản trình chiếu mới bắt đầu với số slide 1, vì vậy văn bản là `Slide 1`, và cả hai kiểm tra đều in ra `true`. Số vẫn ở dạng trường sau khi mở lại; nó không phải là nguyên mẫu `1`. Các chỉ mục trong quá trình xác minh đề cập đến hình dạng và các phần được tạo bởi ví dụ này.

## **Chọn Kiểu Trường**

[FieldType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/) cung cấp các phương thức sau để lấy các giá trị đã định trước. Chuyển giá trị thích hợp vào [addField](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#addField).

| Phương thức | Mục đích |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Số slide hiện tại. |
| [getDateTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Ngày/giờ theo định dạng mặc định của ứng dụng render. |
| [getDateTime1](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Định dạng ngày đã định trước hoặc định dạng kết hợp ngày/giờ. |
| [getDateTime10](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Định dạng thời gian đã định trước, với tùy chọn giây và đồng hồ 12 giờ. |
| [getHeader](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getHeader) | Trường tiêu đề; xem các hạn chế về placeholder và định dạng bên dưới. |
| [getFooter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getFooter) | Trường chân trang. |

Ví dụ, [getDateTime3](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getDateTime3) đại diện cho ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường đã định trước, không phải chuỗi định dạng ngày tùy ý. Ngôn ngữ được đặt bằng [setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) và ứng dụng xử lý bản trình chiếu có thể ảnh hưởng đến kết quả hiển thị.

## **Tạo Trường Từ Chuỗi Nội Bộ**

Phiên bản chấp nhận chuỗi của [addField](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#addField) nhận một định danh trường nội bộ. Sử dụng nó khi cần giữ định danh được cung cấp bởi một ứng dụng khác mà không có giá trị đã định trước. Bạn cũng có thể tạo một [FieldType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/) từ định danh đó. [FieldType.getInternalString](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fieldtype/#getInternalString) cung cấp định danh đó để kiểm tra.

Ví dụ này lưu trữ một trường `custom-report-id` đặc thù của ứng dụng với văn bản dự phòng `Report-042`. Định danh này không đăng ký tính toán: Aspose.Slides không tạo ID báo cáo cho loại không xác định. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị của nó.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Sau vòng quay PPTX này, kiểu là `custom-report-id` và văn bản là `Report-042`. Truyền một chuỗi như `yyyy-MM-dd` sẽ đặt tên cho kiểu trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với ngày cố định ở định dạng tùy ý, sử dụng văn bản thường.

## **Kiểm tra, Sửa đổi và Xóa Trường Ngày/Giờ**

Thay đổi một trường hiện có bằng [Field.setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/field/#setType). Kiểm tra trường tồn tại trước khi truy cập loại của nó. Để dừng cập nhật tự động, gọi [Portion.removeField](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#removeField). Thao tác này giữ phần và văn bản hiện tại trong khi loại bỏ liên kết với trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi xóa trường.

Đối với cài đặt API liên quan đến xử lý trường ngày/giờ, xem [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Ví dụ dưới đây sử dụng ngày phê duyệt cụ thể khi chuyển một trường thành văn bản thường.

Tải về [sample.pptx](sample.pptx) và đặt nó trong thư mục làm việc. Tệp chứa hai hình dạng văn bản có tên, `UpdatedAt` và `ApprovedDate`, mỗi hình đều có trường ngày/giờ, cộng với các nhãn văn bản thường. Ví dụ sau duyệt các hình dạng văn bản cấp cao trên các slide thường. Nó chuyển các trường ngày/giờ sang định dạng ngày dài và in nghiêng, đồng thời giữ nguyên các định dạng khác. Chỉ các trường trong `ApprovedDate` trở thành văn bản cố định.

Ngày phê duyệt là 5 tháng 4, 2030; chỉ mục tháng trong JavaScript bắt đầu từ 0, vì vậy tháng 4 là `3`. UTC được sử dụng cho cả việc tạo và định dạng để ngày không phụ thuộc vào múi giờ địa phương.

Mẫu nhận ra các định danh nội bộ tích hợp sẵn `datetime` và `datetime1` đến `datetime13`. Nhóm, bảng, ghi chú, bố cục và bản mẫu yêu cầu duyệt các container văn bản riêng của chúng và nằm ngoài phạm vi của ví dụ này.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Sau khi mở lại, `UpdatedAt` có kiểu `datetime3` và vẫn là động. `ApprovedDate` không có trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, cài đặt in đậm và màu sắc gốc vẫn giữ nguyên. Các nhãn văn bản thường không thay đổi. Quá trình xác minh đọc phần đầu tiên của hai hình dạng đã biết trong mẫu được cung cấp.

## **Bảo tồn Định dạng Văn bản**

Làm việc với phần hiện có khi thêm trường, thay đổi kiểu hoặc xóa nó. Các thao tác này giữ nguyên định dạng của phần đó. Sử dụng [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#getPortionFormat) để chỉ thay đổi các thuộc tính cần thiết, như các ví dụ cho màu hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc này có thể làm mất ranh giới phần ban đầu và định dạng riêng của chúng. Cũng nên phân biệt định dạng được đặt một cách rõ ràng với định dạng kế thừa từ đoạn, bố cục hoặc giao diện. Xem [Text Formatting](/slides/vi/nodejs-java/text-formatting/) để biết các tùy chọn định dạng rộng hơn.

## **Trường và Placeholder Đầu/Chân Trang**

Một trường là một phần của đoạn văn bản. Một placeholder là một hình dạng có vai trò trong bản trình chiếu, chẳng hạn như chân trang hoặc số slide. Thêm một trường vào hộp văn bản thường không biến hình dạng đó thành placeholder.

Trình quản lý đầu/chân trang điều khiển văn bản placeholder và khả năng hiển thị trên slide, bố cục và bản mẫu, bao gồm việc lan truyền tới các slide phụ thuộc. Do đó, một trường số trong hộp văn bản tùy chỉnh có thể hữu ích ngay cả khi bạn không sử dụng placeholder số slide. Ngược lại, thay đổi khả năng hiển thị placeholder không loại bỏ trường khỏi một hộp văn bản không liên quan.

Các kiểu đầu và chân trang đã định trước không tạo ra các placeholder tương ứng hoặc cung cấp nội dung của chúng. Đặc biệt, một slide PowerPoint thông thường không có placeholder đầu; tiêu đề thuộc về trang ghi chú và tài liệu phát tay. Đừng giả định rằng một trường đầu hoặc chân trang trong một hình dạng bất kỳ sẽ tự động nhận được văn bản được cấu hình qua trình quản lý placeholder. Đối với quy trình này, xem [Presentation Headers and Footers](/slides/vi/nodejs-java/presentation-header-and-footer/).

## **Hạn chế của PPTX và PPT**

Kiểm tra cả kiểu trường và văn bản kết quả của nó sau khi lưu và mở lại. Giữ lại một định danh không chứng minh rằng một ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định dạng | Hành vi và hạn chế của trường |
|---|---|
| PPTX | Lưu trữ các định danh trường nội bộ cùng với văn bản trường. Trong các kiểm tra vòng quay, các kiểu đã định trước và định danh tùy chỉnh được sử dụng ở trên vẫn tồn tại sau khi lưu và mở lại. Kiểu tùy chỉnh không biết vẫn giữ văn bản dự phòng; nó không nhận được logic tính toán tự động. Ứng dụng khác có thể xử lý các định danh không hỗ trợ khác nhau. |
| PPT | Sử dụng các biểu diễn trường legacy và có tính tương thích hạn chế hơn. Trong các kiểm tra vòng quay, trường số slide và trường ngày/giờ đã định trước vẫn tồn tại sau khi lưu và mở lại. Một trường tùy chỉnh trong hộp văn bản slide thông thường mở lại với định danh nhưng với văn bản là `*`; một trường tiêu đề trong cùng ngữ cảnh cũng tạo ra `*`. Không nên dựa vào các trường tùy chỉnh hoặc ngữ cảnh trường không hỗ trợ để giữ lại văn bản hiển thị. |

Để có đầu ra cố định, di động, chuyển các trường không được hỗ trợ thành văn bản thường và gán rõ ràng giá trị mong muốn trước khi lưu. Điều này bảo tồn văn bản đã chọn nhưng cố ý dừng cập nhật tự động. Cũng nên kiểm tra ứng dụng đích khi việc tính lại trường của nó là một phần của quy trình làm việc của bạn.

## **Câu hỏi thường gặp**

**Làm sao tôi biết một số hoặc ngày hiển thị có phải là trường không?**

Kiểm tra [Portion.getField](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#getField). Giá trị không null xác định một trường; chỉ dựa vào văn bản hiển thị không đủ để biết.

**Việc xóa một trường có xóa văn bản hoặc định dạng của nó không?**

Không. [removeField](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#removeField) chuyển phần hiện có thành văn bản thường. Gán một giá trị cụ thể sau đó nếu bạn cần một ngày cố định hoặc giá trị dự phòng.

**Chuỗi nội bộ có thể định nghĩa định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một kiểu trường. Định danh không biết không cung cấp bộ đánh giá hay mẫu định dạng ngày. Sử dụng kiểu đã hỗ trợ hoặc tự định dạng giá trị dưới dạng văn bản thường.

**Tại sao phải kiểm tra lại bản trình chiếu sau khi lưu?**

Vì các định danh trường, văn bản đã tính và định dạng là những yếu tố riêng biệt cần xác thực. Việc chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay cả khi định danh trường vẫn còn.