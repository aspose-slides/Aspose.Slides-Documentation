---
title: Đánh giá Aspose.Slides
type: docs
weight: 120
url: /vi/nodejs-net/evaluate-aspose-slides/
keywords:
- đánh giá Aspose.Slides
- phiên bản đánh giá
- dấu bản quyền đánh giá
- hạn chế dùng thử
- giấy phép tạm thời
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Những giới hạn của phiên bản đánh giá Aspose.Slides cho Node.js qua .NET, kèm một script hiển thị cả hai hạn chế và cách loại bỏ chúng bằng giấy phép."
---
## **Tổng quan**

Phiên bản đánh giá của Aspose.Slides cho Node.js thông qua .NET là cùng một gói npm với phiên bản có giấy phép. Nếu không có giấy phép, nó chạy ở chế độ đánh giá: mọi tính năng vẫn hoạt động, nhưng các bản trình chiếu đã lưu và phần lớn các xuất khẩu có dấu bản quyền, và văn bản mà mã của bạn đọc lại bị cắt ngắn. Bài viết này mô tả cả hai hạn chế và chỉ cách loại bỏ chúng.

## **Các hạn chế của phiên bản đánh giá**

**Một dấu bản quyền đánh giá trên mỗi slide.** Khi bạn lưu một bản trình chiếu mà không có giấy phép, Aspose.Slides sẽ thêm một hộp văn bản vào giữa mỗi slide của tệp đã lưu. Hộp văn bản này bị khóa và hiển thị "Evaluation only." kèm theo một dòng sản phẩm và một dòng bản quyền. Dấu bản quyền được ghi vào tệp đã lưu, không phải vào bản trình chiếu trong bộ nhớ, và việc mở một bản trình chiếu không tự động thêm nó. Tuy nhiên, một tệp đã được lưu trong chế độ đánh giá đã chứa hộp văn bản này, vì vậy việc mở và lưu lại lại sẽ thêm một dấu bản quyền thứ hai vào mỗi slide.

Đánh dấu bản quyền tương tự được vẽ vào kết quả khi bạn xuất ra PDF, XPS hoặc HTML, hoặc render các slide thành hình ảnh. Nếu bạn render một bản trình chiếu đã được lưu trong chế độ đánh giá, hình ảnh sẽ hiển thị cả dấu bản quyền đã lưu và dấu bản quyền được render.

**Văn bản bị cắt ngắn khi mã của bạn đọc nó.** Văn bản mà mã của bạn đọc thông qua thuộc tính `text` của một khung văn bản, đoạn văn hoặc phần được cắt ngắn lại còn năm ký tự đầu tiên, sau đó là thông báo "... text has been truncated due to evaluation version limitation." Văn bản có năm ký tự hoặc ít hơn sẽ được trả về đầy đủ. Điều này áp dụng cho mọi slide, và ngay cả với văn bản mà mã của bạn vừa mới gán. Các xuất khẩu Markdown và HTML5 cũng bị cắt ngắn theo cùng cách.

Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ: các tệp PPTX, trang PDF và hình ảnh slide chứa toàn bộ văn bản.

## **Xem các hạn chế trong một kịch bản**

Kịch bản sau đây hiển thị cả hai hạn chế. Nó giả định rằng bạn đã cài đặt gói như mô tả trong [Installation](/slides/vi/nodejs-net/installation/) và bạn chạy nó từ thư mục dự án. Nó thêm một hình chữ nhật chứa một câu vào slide đầu tiên, đọc lại câu đó, lưu bản trình chiếu dưới tên `evaluation.pptx`, sau đó mở lại tệp để đếm số hình trên slide.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Không có giấy phép, chỉ trả về năm ký tự đầu tiên.
    console.log("Text read back:", rectangle.textFrame.text);

    // Lưu sẽ thêm dấu bản quyền đánh giá vào mỗi slide của tệp.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // Slide hiện chứa hình chữ nhật và hộp văn bản dấu bản quyền.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Không có giấy phép, kịch bản sẽ in:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

Hình dạng thứ hai là hộp văn bản dấu bản quyền. Mở `evaluation.pptx` để xem câu đầy đủ trong hình chữ nhật và dấu bản quyền ở giữa slide.

## **Xóa bỏ các hạn chế**

Để loại bỏ cả hai hạn chế, hãy áp dụng giấy phép trước khi bạn tạo bất kỳ đối tượng `Presentation` nào. [Licensing](/slides/vi/nodejs-net/licensing/) cho thấy cách áp dụng tệp giấy phép.

{{% alert color="success" title="Tip" %}}
Để thử Aspose.Slides mà không gặp các hạn chế đánh giá trước khi mua, yêu cầu một **giấy phép tạm thời 30 ngày** miễn phí. Xem [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) để biết chi tiết.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Chế độ đánh giá có giới hạn số lượng slide không?**  
Không. Các bản trình chiếu được tạo, mở và lưu với tất cả các slide của chúng. Dấu bản quyền và việc cắt ngắn văn bản áp dụng cho mỗi slide một cách đồng đều.

**Tại sao hình ảnh slide xuất ra của tôi lại hiển thị dấu bản quyền hai lần?**  
Bản trình chiếu đã được lưu ở chế độ đánh giá trước khi bạn render, vì vậy nó đã chứa một hộp văn bản dấu bản quyền, và việc render mà không có giấy phép sẽ vẽ thêm một dấu bản quyền khác lên trên.

**Tôi có thể kiểm tra rằng mã của mình tạo ra văn bản đúng khi ở chế độ đánh giá không?**  
Có. Mở tệp đã lưu hoặc PDF đã xuất: chúng chứa toàn bộ văn bản. Chỉ văn bản mà mã của bạn đọc lại, và đầu ra Markdown hoặc HTML5, mới bị cắt ngắn.