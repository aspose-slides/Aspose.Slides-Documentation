---
title: Tự động hoá việc địa phương hoá bài thuyết trình trong .NET
linktitle: Địa phương hoá bài thuyết trình
type: docs
weight: 100
url: /vi/net/presentation-localization/
keywords:
- đổi ngôn ngữ
- kiểm tra chính tả
- id ngôn ngữ
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tự động hoá việc địa phương hoá slide PowerPoint và OpenDocument trong .NET với Aspose.Slides, sử dụng các mẫu mã C# thực tiễn và mẹo để triển khai toàn cầu nhanh hơn."
---
## **Tổng quan**

Bài viết này giải thích cách đặt `LanguageId` cho văn bản trong một bản trình bày bằng cách sử dụng Aspose.Slides. Nó cho thấy cách mở một bản trình bày, thêm một hình dạng có văn bản, gán định danh ngôn ngữ cho một phần văn bản và lưu kết quả dưới dạng tệp PPTX.

## **Thay đổi ngôn ngữ cho bản trình bày và văn bản hình dạng**
- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape loại Hình chữ nhật vào slide.
- Thêm một số văn bản vào TextFrame.
- Đặt Language Id cho văn bản.
- Ghi bản trình bày dưới dạng tệp PPTX.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**ID ngôn ngữ có kích hoạt việc dịch tự động văn bản không?**

Không. [LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/languageid/) trong Aspose.Slides lưu trữ ngôn ngữ cho việc kiểm tra chính tả và chứng minh ngữ pháp, nhưng nó không dịch hoặc thay đổi nội dung văn bản. Nó là siêu dữ liệu mà PowerPoint hiểu để chứng minh.

**ID ngôn ngữ có ảnh hưởng đến việc gạch nối và ngắt dòng khi hiển thị không?**

Trong Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/languageid/) chỉ dành cho việc chứng minh. Chất lượng gạch nối và việc ngắt dòng chủ yếu phụ thuộc vào việc có sẵn [proper fonts](/slides/vi/net/powerpoint-fonts/) và cài đặt bố cục/ngắt dòng cho hệ thống viết. Để đảm bảo hiển thị đúng, hãy cung cấp các phông chữ cần thiết, cấu hình [font substitution rules](/slides/vi/net/font-substitution/), và/hoặc [embed fonts](/slides/vi/net/embedded-font/) vào bản trình bày.

**Tôi có thể đặt các ngôn ngữ khác nhau trong cùng một đoạn văn không?**

Có. [LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/languageid/) được áp dụng ở cấp độ phần văn bản, vì vậy một đoạn văn duy nhất có thể pha trộn nhiều ngôn ngữ với các cài đặt chứng minh riêng biệt.