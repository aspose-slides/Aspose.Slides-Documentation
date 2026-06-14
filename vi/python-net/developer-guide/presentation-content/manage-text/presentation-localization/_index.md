---
title: "Tự động hoá việc địa phương hoá bản trình chiếu bằng Python"
linktitle: "Địa phương hoá bản trình chiếu"
type: docs
weight: 100
url: /vi/python-net/presentation-localization/
keywords:
  - "thay đổi ngôn ngữ"
  - "kiểm tra chính tả"
  - "định danh ngôn ngữ"
  - "PowerPoint"
  - "bản trình chiếu"
  - "Python"
  - "Aspose.Slides"
description: "Tự động hoá việc địa phương hoá slide PowerPoint và OpenDocument trong Python với Aspose.Slides, sử dụng các mẫu mã thực tế và mẹo để triển khai toàn cầu nhanh hơn."
---
## **Tổng quan**

Bài viết này giải thích cách đặt `language_id` cho văn bản trong một bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách mở một bản trình chiếu, thêm một hình dạng có văn bản, gán định danh ngôn ngữ cho một phần văn bản, và lưu kết quả dưới dạng tệp PPTX.

## **Thay đổi Ngôn ngữ cho Bản trình chiếu và Văn bản của Đối tượng**
- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape loại Hình chữ nhật vào slide.
- Thêm một số văn bản vào TextFrame.
- Đặt Language Id cho văn bản.
- Ghi bản trình chiếu ra tệp PPTX.

Việc thực hiện các bước trên được minh họa dưới đây trong một ví dụ.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Does language ID trigger automatic text translation?**

Không. [language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/language_id/) trong Aspose.Slides lưu trữ ngôn ngữ cho việc kiểm tra chính tả và ngữ pháp, nhưng không dịch hoặc thay đổi nội dung văn bản. Đây là siêu dữ liệu mà PowerPoint hiểu để kiểm tra.

**Does language ID affect hyphenation and line breaks during rendering?**

Trong Aspose.Slides, [language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/language_id/) dùng cho việc kiểm tra. Chất lượng gạch nối và việc ngắt dòng chủ yếu phụ thuộc vào sự có sẵn của [proper fonts](/slides/vi/python-net/powerpoint-fonts/) và các cài đặt layout/ngắt dòng cho hệ thống viết. Để đảm bảo render đúng, hãy cung cấp các phông chữ cần thiết, cấu hình [font substitution rules](/slides/vi/python-net/font-substitution/), và/hoặc [embed fonts](/slides/vi/python-net/embedded-font/) vào bản trình chiếu.

**Can I set different languages within a single paragraph?**

Có. [language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/language_id/) được áp dụng ở mức phần văn bản, vì vậy một đoạn văn có thể trộn nhiều ngôn ngữ với các cài đặt kiểm tra riêng biệt.