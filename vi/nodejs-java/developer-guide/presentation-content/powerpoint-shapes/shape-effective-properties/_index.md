---
title: Lấy Thuộc tính Hiệu quả của Hình từ Bản trình chiếu trong JavaScript
linktitle: Thuộc tính Hiệu quả
type: docs
weight: 50
url: /vi/nodejs-java/shape-effective-properties/
keywords:
- thuộc tính hình
- thuộc tính camera
- bộ ánh sáng
- hình chạm trổ
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng tô màu
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách sử dụng Aspose.Slides cho Node.js qua Java để phân biệt định dạng hình cục bộ, kế thừa và hiệu quả trong các bản trình chiếu PowerPoint."
---
## **Hiểu các Thuộc tính Cục bộ, Kế thừa và Hiệu quả**

Định dạng PowerPoint có thể đến từ nhiều nguồn. Giá trị được lưu trữ trực tiếp trên một đối tượng là **giá trị cục bộ**. Nếu giá trị đó không được thiết lập, PowerPoint sẽ tìm các nguồn định dạng cha, chẳng hạn như mặc định đoạn văn, kiểu văn bản, bố cục hoặc slide chủ, một chủ đề, hoặc các mặc định ở mức trình chiếu. Những giá trị đó là **giá trị kế thừa**. Giá trị còn lại sau khi toàn bộ cây kế thừa được giải quyết là **giá trị hiệu quả** — giá trị được sử dụng để hiển thị đối tượng.

Ví dụ, một phần văn bản có thể không xác định chiều cao phông chữ riêng. Giá trị cục bộ của nó đối với [getFontHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getFontHeight) sẽ là `NaN`, nghĩa là “không được đặt ở đây”. Phần này có thể kế thừa chiều cao từ đoạn văn, kiểu văn bản mặc định của bản trình chiếu, hoặc một nguồn áp dụng khác. Gọi [getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getEffective) trên đối tượng PortionFormat sẽ trả về chiều cao đã được giải quyết cuối cùng.

Sử dụng hai loại dữ liệu định dạng cho các mục đích khác nhau:

- Đọc hoặc thay đổi một đối tượng định dạng cục bộ, chẳng hạn như [PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/), khi bạn cần kiểm soát nơi giá trị được định nghĩa.
- Đọc [dữ liệu hiệu quả được trả về bởi PortionFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getEffective) khi bạn cần kết quả cuối cùng đã được hiển thị. Dữ liệu hiệu quả chỉ đọc.

Trước khi chạy các ví dụ, [cài đặt Aspose.Slides cho Node.js qua Java](/slides/vi/nodejs-java/installation/).

## **So sánh Giá trị Cục bộ, Kế thừa và Hiệu quả**

Ví dụ hoàn chỉnh dưới đây tạo một hình dạng và áp dụng chiều cao phông chữ ở mức trình chiếu, đoạn văn và phần. Mỗi bước in ra các giá trị được định nghĩa ở các mức đó và giá trị hiệu quả kết quả cho cùng một phần văn bản. Nó cũng minh họa lý do tại sao dữ liệu hiệu quả phải được đọc lại sau khi thay đổi định dạng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Đọc dữ liệu hiệu quả sau các thay đổi trước đó.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Xác định các giá trị kế thừa ở hai mức độ khác nhau.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Giá trị cục bộ trên phần ghi đè cả hai giá trị kế thừa.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Việc thay đổi giá trị kế thừa không ghi đè giá trị cục bộ hiện có.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Xóa giá trị cục bộ. Phần hiện lại kế thừa từ đoạn văn.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Xóa giá trị đoạn văn. Mặc định của bản trình chiếu hiện cung cấp kết quả.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ưu tiên trong ví dụ này là định dạng cục bộ của phần, sau đó là định dạng đoạn văn, và cuối cùng là mặc định của trình chiếu. Các đối tượng khác có thể có chuỗi kế thừa khác nhau, nhưng nguyên tắc vẫn giống nhau: một giá trị cụ thể hơn sẽ thắng, và [getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getEffective) trả về kết quả cuối cùng.

## **Lấy Thuộc tính Văn bản Hiệu quả**

Định dạng văn bản được chia qua nhiều đối tượng:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#getEffective) xác định các thuộc tính khung văn bản như lề, neo, tự động vừa, và hướng văn bản dọc.
- [TextStyle.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textstyle/#getEffective) xác định định dạng đoạn văn cho mỗi cấp độ kiểu văn bản.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#getEffective) xác định các thuộc tính đoạn văn như căn chỉnh, thụt lề và dấu đầu dòng.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getEffective) xác định các thuộc tính ký tự như chiều cao phông chữ, kiểu chữ, màu, in đậm và in nghiêng.

Đối với ví dụ tiếp theo, tệp `text-formatting.pptx` phải chứa ít nhất một slide và một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) có khung văn bản không rỗng. AutoShape có thể xuất hiện ở bất kỳ vị trí nào trong bộ sưu tập hình dạng; mã sẽ tìm một đối tượng phù hợp và xác thực nó trước khi sử dụng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính 3D Hiệu quả**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getEffective) trả về một đối tượng dữ liệu hiệu quả nhóm tất cả các thiết lập 3D đã được giải quyết. Các phương thức [getCamera](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getBevelTop) và [getBevelBottom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getBevelBottom) hiển thị dữ liệu hiệu quả tương ứng. Đọc những cài đặt liên quan này cùng nhau giúp hiểu dễ hơn về ngoại hình 3D cuối cùng của một hình dạng.

Đối với ví dụ này, tệp `shape-3d.pptx` phải chứa ít nhất một hình dạng trên slide đầu tiên. Áp dụng cài đặt camera 3D, ánh sáng hoặc đỉnh nhọn cho hình dạng đó nếu bạn muốn kết quả có các giá trị khác với mặc định.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Lấy Định dạng Bảng Hiệu quả**

Định dạng bảng có thể đến từ kiểu bảng và từ các định dạng được áp dụng cho toàn bộ bảng, một cột, một hàng hoặc một ô riêng lẻ. Khi có xung đột giữa các màu nền được xác định rõ ràng, ưu tiên là ô, hàng, cột, và sau đó là toàn bộ bảng. Định dạng hiệu quả của một ô là định dạng cuối cùng được dùng để vẽ ô đó.

Đối với ví dụ này, tệp `table-formatting.pptx` phải chứa ít nhất một bảng trên slide đầu tiên. Bảng phải có ít nhất một hàng và một cột. Mã sẽ tìm một [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/) thay vì giả định rằng `getShapes().get_Item(0)` là một bảng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Nếu bạn cần màu thay vì chỉ loại nền, trước tiên kiểm tra [getFillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/#getFillType) hiệu quả, rồi đọc phương thức áp dụng cho loại đó — ví dụ, [getSolidFillColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) cho nền đặc.

## **Đọc lại Dữ liệu Hiệu quả sau Khi Thay đổi**

Dữ liệu hiệu quả mô tả cây định dạng tại thời điểm nó được giải quyết. Gọi lại `getEffective` sau khi thay đổi bất kỳ yếu tố nào có thể tham gia vào cây này, bao gồm:

- định dạng cục bộ của đối tượng;
- mặc định đoạn văn hoặc khung văn bản;
- kiểu bảng, bảng, cột, hàng hoặc định dạng ô;
- định dạng bố cục hoặc slide chủ;
- dữ liệu chủ đề hoặc mặc định ở mức trình chiếu;
- bố cục hoặc slide chủ được gán cho một slide.

Không nên giữ một đối tượng dữ liệu hiệu quả như một ảnh chụp cố định. Aspose.Slides có thể lưu trữ một số dữ liệu hiệu quả trong bộ nhớ trong, và một lời gọi `getEffective` sau này có thể làm mới dữ liệu đó. Nếu bạn cần so sánh các giá trị trước và sau khi thay đổi, hãy sao chép các giá trị thuần cần thiết — chẳng hạn như chiều cao phông chữ, màu, căn chỉnh hoặc độ rộng bevel — vào các biến của bạn trước khi thực hiện thay đổi.

Để thay đổi một giá trị, cập nhật đối tượng định dạng cục bộ thích hợp và sau đó gọi `getEffective` để xác minh kết quả. Các đối tượng dữ liệu hiệu quả tự chúng chỉ đọc.

## **Câu hỏi thường gặp**

**Làm sao tôi biết mức nào cung cấp giá trị hiệu quả?**

Dữ liệu hiệu quả chứa giá trị cuối cùng, không phải nguồn gốc của nó. Kiểm tra các đối tượng cục bộ áp dụng từ mức cụ thể nhất ra ngoài. Đối với văn bản, điều này có thể bao gồm phần, đoạn văn, khung văn bản, bố cục, slide chủ, chủ đề và các mặc định của trình chiếu. Các giá trị không xác định như `NaN` hoặc `null` cho biết việc tìm kiếm tiếp tục ở mức khác.

**Điều gì xảy ra khi không có mức nào định nghĩa thuộc tính?**

Aspose.Slides sẽ giải quyết giá trị mặc định thích hợp của PowerPoint hoặc thư viện. Giá trị đã được giải quyết này xuất hiện trong dữ liệu hiệu quả ngay cả khi không có đối tượng cục bộ nào định nghĩa rõ ràng nó.

**Tại sao đôi khi giá trị hiệu quả bằng với giá trị cục bộ?**

Giá trị cục bộ đã thắng trong quá trình tính kế thừa. Điều này là mong đợi khi thuộc tính được đặt rõ ràng trên đối tượng và không có quy tắc cụ thể hơn nào ghi đè lên nó.

**Khi nào tôi nên sử dụng dữ liệu cục bộ thay vì dữ liệu hiệu quả?**

Sử dụng dữ liệu cục bộ để kiểm tra hoặc chỉnh sửa một mức định dạng cụ thể. Sử dụng dữ liệu hiệu quả khi bạn cần ngoại hình cuối cùng sau khi kế thừa, quy tắc chủ đề và các kiểu áp dụng đã được giải quyết. [Ví dụ so sánh đầy đủ](#compare-local-inherited-and-effective-values) minh họa cả hai trong cùng một quy trình làm việc.