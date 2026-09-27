---
title: Tham chiếu API
type: docs
weight: 50
url: /vi/nodejs-net/api-reference/
description: "Aspose.Slides cho Node.js qua .NET được tài liệu hoá bằng tài liệu API Aspose.Slides cho .NET. Xem cách các tên lớp và thành viên .NET được ánh xạ sang JavaScript."
---
## **Tổng quan**

Aspose.Slides cho Node.js qua .NET không có tài liệu API riêng. Gói này công bố các lớp của Aspose.Slides cho .NET cho JavaScript dưới cùng các tên, với các thành viên dạng camelCase, vì vậy [tài liệu API Aspose.Slides cho .NET](https://reference.aspose.com/slides/vi/net/) ghi lại các lớp, thành viên và enumeration của nó.

## **Ánh xạ tên .NET sang JavaScript**

- **Các lớp và enumeration giữ nguyên tên .NET**, và các giá trị enumeration cũng vậy: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Nhập chúng từ gói: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Thuộc tính và phương thức bắt đầu bằng chữ thường.** `Presentation.Slides` trở thành `presentation.slides`, và `ShapeCollection.AddAutoShape` trở thành `shapes.addAutoShape`. Thuộc tính vẫn là thuộc tính: bạn đọc và gán chúng mà không cần dấu ngoặc đơn.
- **Các phần tử của collection được đọc bằng `get(index)`**, và số lượng phần tử bằng `count`: `presentation.slides.get(0)` thay vì `presentation.Slides[0]`.
- **Một số overload có tên riêng.** Ví dụ, overload `Slide.GetImage(Size)` là `slide.getImageWithImageSize({ width, height })`. Các overload khác chia sẻ một phương thức với các đối số tùy chọn ở cuối: `presentation.save(path, format, options, slides)` bao phủ nhiều overload của `Presentation.Save`, và `new Presentation(null, buffer)` mở một bài thuyết trình từ một `Buffer`. Mỗi lớp là một tệp trong thư mục `lib` của gói (ví dụ, `node_modules/aspose.slides.via.net/lib/Slide.js`), nơi bạn có thể tra cứu các tên chính xác.
- **Giải phóng các bài thuyết trình bằng `dispose`** khi bạn hoàn thành; JavaScript không có câu lệnh `using`.

Gói không bao bọc mọi thành viên .NET. Nếu một thành viên từ tài liệu API .NET không có trong tệp lớp, nó sẽ không khả dụng trong JavaScript.

## **Ví dụ**

Đoạn script sau đây sử dụng các quy tắc ở trên. Mỗi chú thích hiển thị lời gọi .NET mà dòng tiếp theo tương ứng. Nó thêm một hình chữ nhật có văn bản vào slide đầu tiên, render slide thành ảnh PNG kích thước 960 × 540 pixel, và lưu bài thuyết trình dưới dạng PDF. Chạy nó từ thư mục dự án nơi gói được cài đặt như mô tả trong [Cài đặt](/slides/vi/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Script sẽ ghi `slide.png` và `slide.pdf` vào thư mục hiện tại. Cả hai đều hiển thị hình chữ nhật với văn bản của nó. Nếu không có giấy phép, chúng cũng sẽ hiển thị watermark đánh giá; xem [Cấp phép](/slides/vi/nodejs-net/licensing/).

Để biết chi tiết về các thành viên được sử dụng ở đây, xem [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/text/) và [Slide.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage/) trong tài liệu API Aspose.Slides cho .NET.