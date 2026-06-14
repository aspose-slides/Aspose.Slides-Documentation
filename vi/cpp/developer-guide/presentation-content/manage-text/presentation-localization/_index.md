---
title: Tự động hoá việc địa phương hoá bản trình chiếu trong C++
linktitle: Địa phương hoá bản trình chiếu
type: docs
weight: 100
url: /vi/cpp/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- id ngôn ngữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tự động hoá việc địa phương hoá các slide PowerPoint và OpenDocument trong C++ với Aspose.Slides, sử dụng các mẫu mã thực tế và mẹo để triển khai toàn cầu nhanh hơn."
---
## **Tổng quan**

Bài viết này giải thích cách đặt `LanguageId` cho văn bản trong một bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách mở một bản trình chiếu, thêm một hình dạng có văn bản, gán một định danh ngôn ngữ cho một phần văn bản, và lưu kết quả dưới dạng tệp PPTX.

## **Thay đổi ngôn ngữ cho bản trình chiếu và văn bản hình dạng**
- Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) class.
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape loại Rectangle vào slide.
- Thêm một số văn bản vào TextFrame.
- Đặt Language Id cho văn bản.
- Lưu bản trình chiếu dưới dạng tệp PPTX.

Việc triển khai các bước trên được minh họa dưới đây trong một ví dụ.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **Câu hỏi thường gặp**

**ID ngôn ngữ có kích hoạt dịch tự động không?**

Không. [Language ID](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_languageid/) trong Aspose.Slides lưu trữ ngôn ngữ để kiểm tra chính tả và ngữ pháp, nhưng nó không dịch hay thay đổi nội dung văn bản. Đây là siêu dữ liệu mà PowerPoint hiểu để kiểm tra.

**ID ngôn ngữ có ảnh hưởng đến việc ngắt âm tiết và ngắt dòng khi render không?**

Trong Aspose.Slides, [Language ID](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_languageid/) dùng để kiểm tra. Chất lượng ngắt âm tiết và việc bọc dòng chủ yếu phụ thuộc vào việc có sẵn [proper fonts](/slides/vi/cpp/powerpoint-fonts/) và cài đặt layout/ngắt dòng cho hệ thống viết. Để đảm bảo render đúng, hãy cung cấp các phông chữ cần thiết, cấu hình [font substitution rules](/slides/vi/cpp/font-substitution/), và/hoặc [embed fonts](/slides/vi/cpp/embedded-font/) vào bản trình chiếu.

**Tôi có thể đặt ngôn ngữ khác nhau trong cùng một đoạn văn không?**

Có. [Language ID](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_languageid/) được áp dụng ở mức phần văn bản, vì vậy một đoạn văn có thể kết hợp nhiều ngôn ngữ với cài đặt kiểm tra riêng biệt.