---
title: Chuyển đổi bản trình chiếu PowerPoint sang tài liệu Word trên Android
linktitle: PowerPoint sang Word
type: docs
weight: 110
url: /vi/androidjava/convert-powerpoint-to-word/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang Word
- bài thuyết trình sang Word
- slide sang Word
- PPT sang Word
- PPTX sang Word
- PowerPoint sang DOCX
- bài thuyết trình sang DOCX
- slide sang DOCX
- PPT sang DOCX
- PPTX sang DOCX
- PowerPoint sang DOC
- bài thuyết trình sang DOC
- slide sang DOC
- PPT sang DOC
- PPTX sang DOC
- lưu PPT dưới dạng DOCX
- lưu PPTX dưới dạng DOCX
- xuất PPT sang DOCX
- xuất PPTX sang DOCX
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint PPT và PPTX sang tài liệu Word có thể chỉnh sửa trong Java bằng Aspose.Slides cho Android, giữ nguyên bố cục, hình ảnh và định dạng."
---
## **Tổng quan**

Bài viết này cung cấp giải pháp cho nhà phát triển về việc chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word bằng cách sử dụng Aspose.Slides và Aspose.Words. Hướng dẫn từng bước sẽ đưa bạn qua mọi giai đoạn của quá trình chuyển đổi.

## **Aspose.Slides và Aspose.Words**

Để chuyển đổi tệp PowerPoint (PPTX hoặc PPT) sang Word (DOCX hoặc DOCX), bạn cần cả [Aspose.Slides cho Android qua Java](https://products.aspose.com/slides/vi/androidjava/) và [Aspose.Words cho Android qua Java](https://products.aspose.com/words/android-java/).

Là một API độc lập, [Aspose.Slides](https://products.aspose.app/slides) cho Java cung cấp các chức năng cho phép bạn trích xuất văn bản từ các bản trình chiếu.

[Aspose.Words](https://docs.aspose.com/words/androidjava/) là một API xử lý tài liệu nâng cao cho phép các ứng dụng tạo, sửa đổi, chuyển đổi, kết xuất, in file và thực hiện các tác vụ khác với tài liệu mà không cần sử dụng Microsoft Word.

## **Chuyển đổi PowerPoint sang Word**

1. Tải xuống các thư viện [Aspose.Slides cho Android qua Java](https://downloads.aspose.com/slides/vi/java) và [Aspose.Words cho Java](https://downloads.aspose.com/words/java).
2. Thêm *aspose-slides-x.x-jdk16.jar* và *aspose-words-x.x-jdk16.jar* vào CLASSPATH của bạn.
3. Sử dụng đoạn mã này để chuyển đổi PowerPoint sang Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
        // tạo hình ảnh slide dưới dạng luồng mảng byte
        IImage image = slide.getImage(1, 1);
        ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
        image.save(imageStream, ImageFormat.Png);
        image.dispose();

        builder.insertImage(imageStream.toByteArray());

        // chèn văn bản của slide
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof AutoShape) {
                builder.writeln(((AutoShape) shape).getTextFrame().getText());
            }
        }

        builder.insertBreak(BreakType.PAGE_BREAK);
    }

doc.save("output.docx");
pres.dispose();
```

## **Câu hỏi thường gặp**

**Cần cài đặt những thành phần nào để chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word?**

Bạn chỉ cần thêm gói tương ứng cho [Aspose.Slides cho Android qua Java](https://releases.aspose.com/slides/vi/androidjava/) và [Aspose.Words cho Android qua Java](https://releases.aspose.com/words/androidjava/) vào dự án của mình. Cả hai thư viện hoạt động như các API độc lập, và không yêu cầu cài đặt Microsoft Office.

**Có hỗ trợ tất cả các định dạng bản trình chiếu PowerPoint và OpenDocument không?**

Aspose.Slides [hỗ trợ tất cả các định dạng bản trình chiếu](/slides/vi/androidjava/supported-file-formats/), bao gồm PPT, PPTX, ODP và các loại tệp phổ biến khác. Điều này đảm bảo rằng bạn có thể làm việc với các bản trình chiếu được tạo bằng nhiều phiên bản khác nhau của Microsoft PowerPoint.