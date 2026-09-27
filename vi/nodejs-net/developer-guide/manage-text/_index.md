---
title: Quản lý Văn bản Bản trình chiếu trong Node.js qua .NET
linktitle: Quản lý Văn bản
type: docs
weight: 50
url: /vi/nodejs-net/manage-text/
keywords:
- văn bản
- hộp văn bản
- thêm văn bản
- thay đổi văn bản
- định dạng văn bản
- kích thước phông chữ
- văn bản in đậm
- khung văn bản
- đoạn văn
- phần
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm một hộp văn bản vào slide, sau đó thay đổi văn bản, kích thước phông chữ và kiểu in đậm trong JavaScript bằng Aspose.Slides cho Node.js qua .NET."
---
## **Tổng quan**

Trong Aspose.Slides, văn bản trên một slide thuộc về một shape. Một auto shape, chẳng hạn như hình chữ nhật, có một text frame; text frame chứa các đoạn văn (paragraph), và mỗi đoạn văn chứa các portion, là các đoạn văn bản có cùng định dạng. Bạn thay đổi văn bản qua text frame và phông chữ qua format của một portion.

Bài viết này thêm một text box vào slide và lưu bản trình chiếu. Sau đó mở tệp đã lưu và thay đổi văn bản, kích thước phông chữ và kiểu đậm của text box.

Các ví dụ yêu cầu một dự án được thiết lập như mô tả trong [Cài đặt](/slides/vi/nodejs-net/installation/). Lưu mỗi ví dụ dưới dạng tệp `.js` trong thư mục dự án và chạy nó từ thư mục đó bằng `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET has no API reference of its own. It mirrors the Aspose.Slides for .NET API with camelCase names, so the API links in this article lead to the matching classes and members in the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Thêm một Text Box**

Để thêm một text box, thêm một auto shape vào slide bằng phương thức [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) và gán cho nó văn bản bằng phương thức [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/). Ví dụ sau đây thêm một hình chữ nhật vào slide đầu tiên của một bản trình chiếu mới và lưu bản trình chiếu dưới tên `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Vị trí (x, y) và kích thước (rộng, cao) được tính bằng điểm.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Slide trong `text-box.pptx` chứa một hình chữ nhật, rộng 500 điểm và cao 80 điểm, với văn bản "Quarterly report" trong phông chữ và kích thước mặc định. Ví dụ tiếp theo thay đổi text box này.

## **Thay đổi Văn bản và Định dạng của nó**

Ví dụ sau mở `text-box.pptx`, tệp mà ví dụ trước đã tạo, và lấy shape đầu tiên trên slide đầu tiên. Các shape như hình ảnh và bảng không có text frame, vì vậy ví dụ kiểm tra shape có phải là một [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) trước khi sử dụng [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) của shape. Sau đó thực hiện các bước sau:

1. Nó thay thế văn bản qua thuộc tính [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) của text frame. Sau đó, text frame chứa một đoạn văn với một portion.
2. Nó lấy portion đó từ các collection [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) và [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) và đọc [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).
3. Nó đặt [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/), kích thước phông chữ tính bằng điểm, và [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), nhận một giá trị [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

Trong `text-box-updated.pptx`, text box hiển thị "Quarterly report: third quarter" với kiểu in đậm, cỡ 32 điểm. Vì văn bản mới là một portion duy nhất, hai thuộc tính định dạng áp dụng cho toàn bộ. Nếu không có giấy phép, mỗi lần lưu sẽ thêm một watermark đánh giá. Vì `text-box.pptx` đã được lưu ở chế độ đánh giá, `text-box-updated.pptx` chứa hai; xem [Evaluate Aspose.Slides](/slides/vi/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Tại sao `fontBold` nhận giá trị `NullableBool` thay vì `true` hoặc `false`?**

Một portion có thể để lại thuộc tính không xác định và kế thừa từ paragraph, shape, hoặc layout và master của slide. `NullableBool.NotDefined` có nghĩa là "kế thừa", trong khi `NullableBool.True` và `NullableBool.False` ghi đè giá trị kế thừa. Gán `true` hoặc `false` sẽ gây lỗi. Vì lý do tương tự, `fontHeight` trả về `NaN` khi portion kế thừa kích thước phông chữ.

**Làm thế nào để thay đổi màu văn bản?**

Đặt fill của portion format: gán `FillType.Solid` cho `portionFormat.fillFormat.fillType`, sau đó gán một màu như `"#FF0000"` cho `portionFormat.fillFormat.solidFillColor.color`. Thêm `FillType` vào các tên bạn import từ package.

**Làm thế nào để định dạng chỉ một phần của văn bản?**

Định dạng thuộc về các portion, vì vậy đặt phần văn bản đó vào một portion riêng. Tạo portion bằng `Portion.CreatePortionFromText`, thêm nó vào một paragraph bằng phương thức `add` của collection `portions` của paragraph, và sau đó đặt `portionFormat` cho portion mới. Thêm `Portion` vào các tên bạn import từ package.

**Tại sao khi đọc văn bản lại trả về "... text has been truncated due to evaluation version limitation"?**

Nếu không có giấy phép, Aspose.Slides chỉ trả về năm ký tự đầu tiên của bất kỳ văn bản dài nào bạn đọc, chẳng hạn `textFrame.text`, kèm theo thông báo này. Văn bản bạn ghi sẽ được lưu đầy đủ. Áp dụng giấy phép như mô tả trong [Licensing](/slides/vi/nodejs-net/licensing/) để đọc toàn bộ văn bản.