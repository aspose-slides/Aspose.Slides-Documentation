---
title: Quản lý hàng và cột trong bảng PowerPoint bằng JavaScript
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/nodejs-java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- đầu đề bảng
- sao chép hàng
- sao chép cột
- chép hàng
- chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng JavaScript và Aspose.Slides cho Node.js qua Java, đồng thời tăng tốc việc chỉnh sửa bản trình chiếu và cập nhật dữ liệu."
---
## **Giới thiệu**

Aspose.Slides for Node.js via Java cho phép bạn quản lý cấu trúc và định dạng bảng trong các bản thuyết trình PowerPoint thông qua lớp [Bảng](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Bạn có thể chỉ định một hàng tiêu đề, sao chép hoặc xóa các hàng và cột, và áp dụng định dạng văn bản cho toàn bộ hàng hoặc cột.

Bài viết này giải thích các thao tác này bằng các ví dụ JavaScript. Nó cũng cho thấy cách lấy preset kiểu bảng để bạn có thể tái sử dụng. Chỉ mục hàng và cột trong bảng được tính từ 0.

## **Kiểm soát chiều cao hàng**

Sử dụng [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) để đặt chiều cao tối thiểu của một hàng tính bằng điểm. Đây là giới hạn dưới, không phải chiều cao cố định. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) trả về chiều cao thực tế. Truy cập hàng thông qua [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

Ví dụ tải [row-height-input.pptx](row-height-input.pptx), trong đó có một bảng là hình dạng đầu tiên trên slide đầu tiên. Hàng đầu tiên của nó bắt đầu ở 70 điểm. Các ô sử dụng văn bản Arial 18 điểm, có ngắt dòng và lề trên, dưới mỗi ô là 6 điểm; văn bản dài hơn ở cột thứ hai sẽ ngắt thành nhiều dòng. Ví dụ tăng chiều cao tối thiểu lên 100 điểm, sau đó giảm xuống 20 điểm, in ra chiều cao thực tế sau mỗi thay đổi, và lưu cả hai kết quả.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Với bản trình chiếu được cung cấp, việc tăng chiều cao tối thiểu sẽ thêm không gian cho hàng. Việc giảm nó sẽ loại bỏ không gian thừa, nhưng chiều cao thực tế vẫn lớn hơn 20 điểm vì văn bản và lề ô cần nhiều không gian hơn. Chỉ giảm chiều cao tối thiểu không thể buộc hàng xuống dưới mức không gian cần thiết cho nội dung của nó.

Một số yếu tố ảnh hưởng tới chiều cao thực tế:

- **Văn bản và kích thước phông:** văn bản dài hơn, ngắt dòng thủ công, hoặc phông chữ lớn hơn có thể yêu cầu nhiều không gian theo chiều dọc.
- **Ngắt dòng và độ rộng cột:** khi bật ngắt dòng, giảm độ rộng cột bằng [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) có thể tạo ra nhiều dòng hơn. Cột rộng hơn có thể giảm không gian cần thiết theo chiều dọc.
- **Lề ô:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) và [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) thêm không gian dọc. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) và [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) giảm độ rộng có thể dùng cho văn bản và gây ngắt dòng thêm.

Đối với bảng này không có ô được hợp nhất, ô cần không gian dọc nhiều nhất sẽ xác định giới hạn phía dưới được nội dung quyết định cho toàn bộ hàng. Để làm hàng ngắn hơn, bạn cũng có thể cần rút ngắn văn bản, giảm kích thước phông hoặc lề, hoặc mở rộng một cột.

Các hình ảnh dưới đây hiển thị cùng một bảng với cùng tỉ lệ. Trong các kết quả minh hoạ, các chiều cao thực tế là 70, 100 và 55,2 điểm: hàng cuối cùng vẫn cao hơn mức tối thiểu 20 điểm. Các đo lường văn bản chính xác có thể thay đổi tùy vào phông chữ có trong môi trường của bạn. Tải xuống các kết quả đã lưu: [tối thiểu tăng lên](row-height-increased.pptx) và [tối thiểu giảm xuống](row-height-decreased.pptx).

| Gốc: tối thiểu 70 pt, thực tế 70 pt | Tăng: tối thiểu 100 pt, thực tế 100 pt | Giảm: tối thiểu 20 pt, thực tế 55.2 pt |
| --- | --- | --- |
| ![Bảng gốc với hàng đầu tiên có độ cao 70 điểm.](row-height-before.png) | ![Bảng sau khi tăng tối thiểu hàng đầu tiên lên 100 điểm.](row-height-increased.png) | ![Bảng sau khi giảm tối thiểu hàng đầu tiên xuống 20 điểm; văn bản được gói giữ hàng cao hơn mức tối thiểu.](row-height-decreased.png) |

## **Đặt hàng đầu tiên làm tiêu đề**

Sử dụng phương thức [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) để đánh dấu hàng đầu tiên cho định dạng tiêu đề. Hiện diện của nó phụ thuộc vào kiểu bảng được áp dụng cho bảng.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Truy cập bảng được lưu làm hình dạng đầu tiên trên slide.
4. Bật định dạng tiêu đề cho hàng đầu tiên của nó.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên. Nó bật định dạng tiêu đề cho hàng đầu tiên và lưu thành `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sao chép một hàng hoặc cột trong bảng**

Sao chép các hàng hoặc cột để tái sử dụng nội dung và định dạng của chúng. Bạn có thể thêm một bản sao vào cuối bảng hoặc chèn vào vị trí cụ thể.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng các cột và chiều cao các hàng.
4. Thêm bảng bằng phương thức [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Sao chép các hàng cần thiết.
6. Sao chép các cột cần thiết.
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `Test.pptx` có ít nhất một slide. Nó tạo một bảng gồm ba cột và năm hàng, với kích thước được chỉ định bằng điểm. Nó thêm các bản sao của hàng và cột đầu tiên, sau đó chèn các bản sao của hàng và cột thứ hai vào chỉ mục 3 (vị trí thứ tư). Bảng kết quả có bảy hàng và năm cột. Tham số `false` vô hiệu hoá việc sao chép vào các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa một hàng hoặc cột khỏi bảng**

Xóa các hàng hoặc cột không còn cần thiết trong một bảng. Khi xóa một mục, các chỉ mục của các hàng hoặc cột phía sau sẽ bị dịch chuyển.

1. Tạo bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng các cột và chiều cao các hàng.
4. Thêm bảng bằng phương thức [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Xóa hàng thứ hai và cột thứ hai.
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ này tạo một bảng ba‑by‑ba và xóa hàng và cột ở chỉ mục 1, để lại một bảng hai‑by‑hai trong `TestTable_out.pptx`. Các kích thước tính bằng điểm. Tham số `false` vô hiệu hoá việc xóa các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt định dạng văn bản ở mức hàng trong bảng**

Áp dụng định dạng văn bản cho toàn bộ hàng để giữ cho các ô của nó nhất quán. Bạn có thể đặt thuộc tính phông, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) cho hàng đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) và [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) cho hàng đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) cho hàng thứ hai.
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai hàng. Nó áp dụng văn bản 25‑point, căn phải và lề đoạn văn phải 20‑point cho hàng đầu tiên, sau đó đặt văn bản dọc cho hàng thứ hai.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt định dạng văn bản ở mức cột trong bảng**

Áp dụng định dạng văn bản cho toàn bộ cột để giữ cho các ô của nó nhất quán. Bạn có thể đặt thuộc tính phông, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) cho cột đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) và [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) cho cột đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) cho cột thứ hai.
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai cột. Nó áp dụng văn bản 25‑point, căn phải và lề đoạn văn phải 20‑point cho cột đầu tiên, sau đó đặt văn bản dọc cho cột thứ hai.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng phương thức [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) để lấy preset đã áp dụng cho một bảng và tái sử dụng nó cho bảng khác. Điều này nhận dạng preset thay vì các ghi đè định dạng cá nhân trên ô.

Ví dụ tạo một bảng, áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1), và đọc lại preset. Nó in ra giá trị nguyên tương ứng với `DarkStyle1` và lưu bảng trong `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng chủ đề/phong cách PowerPoint cho một bảng đã được tạo chưa?**

Có. Bảng sẽ kế thừa chủ đề slide/bố cục/màn chủ của slide, và bạn vẫn có thể ghi đè màu nền, viền và màu văn bản phía trên chủ đề đó.

**Tôi có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hoặc lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, rồi đưa lại các hàng vào bảng theo thứ tự đó.

**Tôi có thể có các cột dải (có sọc) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật cột dải, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ có ưu tiên cao hơn kiểu bảng.