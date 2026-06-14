---
title: Tự động hoá việc bản địa hoá bản trình chiếu trên Android
linktitle: Bản địa hoá bản trình chiếu
type: docs
weight: 100
url: /vi/androidjava/presentation-localization/
keywords:
- đổi ngôn ngữ
- kiểm tra chính tả
- định danh ngôn ngữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tự động hoá việc bản địa hoá các slide PowerPoint và OpenDocument trong Java với Aspose.Slides cho Android, sử dụng các mẫu mã thực tế và mẹo để triển khai toàn cầu nhanh hơn."
---
## **Tổng quan**

Bài viết này giải thích cách đặt `LanguageId` cho văn bản trong một bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó mô tả cách mở một bản trình chiếu, thêm một hình dạng có văn bản, gán một định danh ngôn ngữ cho một phần văn bản, và lưu kết quả dưới dạng tệp PPTX.

## **Thay đổi ngôn ngữ cho bản trình chiếu và văn bản hình dạng**
- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) .
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) loại [Rectangle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeType#Rectangle) vào slide.
- Thêm một số văn bản vào TextFrame.
- [Cài đặt Language Id](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) cho văn bản.
- Ghi bản trình chiếu dưới dạng tệp PPTX.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Does language ID trigger automatic text translation?**

Không. [Language ID](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) trong Aspose.Slides lưu trữ ngôn ngữ cho việc kiểm tra chính tả và chứng minh ngữ pháp, nhưng nó không dịch hay thay đổi nội dung văn bản. Đó là siêu dữ liệu mà PowerPoint hiểu để kiểm tra.

**Does language ID affect hyphenation and line breaks during rendering?**

Trong Aspose.Slides, [language ID](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) dùng cho việc chứng minh. Chất lượng gạch ngang và việc ngắt dòng chủ yếu phụ thuộc vào tính khả dụng của [proper fonts](/slides/vi/androidjava/powerpoint-fonts/) và các cài đặt bố cục/ngắt dòng cho hệ thống viết. Để đảm bảo hiển thị đúng, hãy cung cấp các phông chữ cần thiết, cấu hình [font substitution rules](/slides/vi/androidjava/font-substitution/), và/hoặc [embed fonts](/slides/vi/androidjava/embedded-font/) vào bản trình chiếu.

**Can I set different languages within a single paragraph?**

Có. [Language ID](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) được áp dụng ở mức phần văn bản, vì vậy một đoạn văn duy nhất có thể kết hợp nhiều ngôn ngữ với các cài đặt chứng minh riêng biệt.