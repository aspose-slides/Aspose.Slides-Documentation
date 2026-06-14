---
title: Tự động hoá bản địa hoá bản trình chiếu trong JavaScript
linktitle: Bản địa hoá bản trình chiếu
type: docs
weight: 100
url: /vi/nodejs-java/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- mã ngôn ngữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tự động hoá việc bản địa hoá các slide PowerPoint và OpenDocument trong JavaScript bằng Aspose.Slides, sử dụng các mẫu mã thực tế và mẹo để triển khai toàn cầu nhanh hơn."
---
## **Tổng quan**

Bài viết này giải thích cách đặt `LanguageId` cho văn bản trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách mở một bản trình chiếu, thêm một hình dạng có văn bản, gán định danh ngôn ngữ cho một phần văn bản và lưu kết quả dưới dạng tệp PPTX.

## **Thay đổi ngôn ngữ cho bản trình chiếu và văn bản của Shape**

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) loại [Rectangle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeType#Rectangle) vào slide.
- Thêm một số văn bản vào TextFrame.
- [Cài đặt Language Id](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) cho văn bản.
- Lưu bản trình chiếu dưới dạng tệp PPTX.

Việc thực hiện các bước trên được minh họa bên dưới trong một ví dụ.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**ID ngôn ngữ có kích hoạt việc dịch tự động văn bản không?**

Không. [setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) trong Aspose.Slides lưu trữ ngôn ngữ cho việc kiểm tra chính tả và ngữ pháp, nhưng nó không dịch hay thay đổi nội dung văn bản. Đó là siêu dữ liệu mà PowerPoint hiểu để proofing.

**ID ngôn ngữ có ảnh hưởng tới việc ngắt từ và ngắt dòng khi hiển thị không?**

Trong Aspose.Slides, `setLanguageId` dùng cho việc proofing. Chất lượng ngắt từ và việc ngắt dòng chủ yếu phụ thuộc vào sự sẵn có của [phông chữ thích hợp](/slides/vi/nodejs-java/powerpoint-fonts/) và cài đặt layout/ngắt dòng cho hệ thống viết. Để đảm bảo hiển thị đúng, hãy cung cấp các phông chữ cần thiết, cấu hình [quy tắc thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/), và/hoặc [nhúng phông chữ](/slides/vi/nodejs-java/embedded-font/) vào bản trình chiếu.

**Tôi có thể đặt các ngôn ngữ khác nhau trong một đoạn văn duy nhất không?**

Có. [setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) được áp dụng ở mức phần văn bản, vì vậy một đoạn văn duy nhất có thể kết hợp nhiều ngôn ngữ với các cài đặt proofing riêng biệt.