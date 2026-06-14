---
title: Chuyển đổi các bài thuyết trình PowerPoint sang tài liệu Word trong Java
linktitle: PowerPoint sang Word
type: docs
weight: 110
url: /vi/java/convert-powerpoint-to-word/
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
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint PPT và PPTX sang tài liệu Word có thể chỉnh sửa trong Java bằng Aspose.Slides, giữ nguyên bố cục, hình ảnh và định dạng một cách chính xác."
---
## **Tổng quan**

Bài viết này cung cấp giải pháp cho các nhà phát triển về việc chuyển đổi bài thuyết trình PowerPoint và OpenDocument sang tài liệu Word bằng Aspose.Slides và Aspose.Words. Hướng dẫn từng bước sẽ dẫn bạn qua mọi giai đoạn của quá trình chuyển đổi.

## **Chuyển đổi PowerPoint sang Word**

Thực hiện các bước sau để chuyển đổi bài thuyết trình PowerPoint hoặc OpenDocument sang tài liệu Word:

1. Tải xuống thư viện [Aspose.Slides for Java](https://downloads.aspose.com/slides/vi/java) và [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Thêm *aspose-slides-x.x-jdk16.jar* và *aspose-words-x.x-jdk16.jar* vào CLASSPATH của bạn.
3. Sử dụng đoạn mã này để chuyển đổi PowerPoint sang Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // tạo một hình ảnh slide dưới dạng luồng byte
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

**Các thành phần nào cần được cài đặt để chuyển đổi bài thuyết trình PowerPoint và OpenDocument sang tài liệu Word?**

Bạn chỉ cần thêm gói tương ứng cho [Aspose.Slides for Java](https://releases.aspose.com/slides/vi/java/) và [Aspose.Words for Java](https://releases.aspose.com/words/java/) vào dự án của mình. Cả hai thư viện hoạt động như các API độc lập, và không yêu cầu cài đặt Microsoft Office.

**Có hỗ trợ tất cả các định dạng bài thuyết trình PowerPoint và OpenDocument không?**

Aspose.Slides [hỗ trợ tất cả các định dạng bài thuyết trình](/slides/vi/java/supported-file-formats/), bao gồm PPT, PPTX, ODP và các loại tệp phổ biến khác. Điều này đảm bảo bạn có thể làm việc với các bài thuyết trình được tạo trên nhiều phiên bản khác nhau của Microsoft PowerPoint.