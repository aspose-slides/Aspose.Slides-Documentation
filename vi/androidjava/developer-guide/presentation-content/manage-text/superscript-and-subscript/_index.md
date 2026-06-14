---
title: Quản lý Siêu Chỉ Số và Chỉ Số Dưới trong Bản Thuyết Trình trên Android
linktitle: Siêu Chỉ Số và Chỉ Số Dưới
type: docs
weight: 80
url: /vi/androidjava/superscript-and-subscript/
keywords:
- siêu chỉ số
- chỉ số dưới
- thêm siêu chỉ số
- thêm chỉ số dưới
- PowerPoint
- OpenDocument
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Nắm vững siêu chỉ số và chỉ số dưới trong Aspose.Slides cho Android bằng Java và nâng cao các bản thuyết trình của bạn với định dạng văn bản chuyên nghiệp để đạt tối đa hiệu quả."
---
## **Overview**

Aspose.Slides cung cấp các tính năng để tích hợp văn bản siêu chỉ số và chỉ số dưới vào các bản thuyết trình PowerPoint (PPT, PPTX) và OpenDocument (ODP) của bạn. Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học, hay chú thích nội dung bằng chú thích chân trang, các tùy chọn định dạng chuyên biệt này giúp duy trì độ rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng các kiểu siêu chỉ số và chỉ số dưới một cách liền mạch và đảm bảo kết quả chuyên nghiệp trên mỗi slide.

## **Manage Superscript and Subscript Text**
Bạn có thể thêm văn bản siêu chỉ số và chỉ số dưới vào bất kỳ phần đoạn văn nào. Để thêm văn bản Superscript hoặc Subscript trong khung văn bản Aspose.Slides, bạn phải sử dụng phương thức [**setEscapement**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) của lớp [PortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PortionFormat).

Thuộc tính này trả về hoặc đặt văn bản siêu chỉ số hoặc chỉ số dưới (giá trị từ -100% (chỉ số dưới) tới 100% (siêu chỉ số)). Ví dụ:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) loại [Rectangle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeType#Rectangle) vào slide.
- Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame) liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape).
- Xóa các Paragraph hiện có
- Tạo một đối tượng paragraph mới để chứa văn bản siêu chỉ số và thêm nó vào [IParagraphs collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) của [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame).
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion từ 0 tới 100 để thêm siêu chỉ số. (0 nghĩa là không có siêu chỉ số)
- Đặt một đoạn văn bản cho [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Portion) và sau đó thêm nó vào bộ sưu tập portion của paragraph.
- Tạo một đối tượng paragraph mới để chứa văn bản chỉ số dưới và thêm nó vào IParagraphs collection của ITextFrame.
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion từ 0 tới -100 để thêm chỉ số dưới. (0 nghĩa là không có chỉ số dưới)
- Đặt một đoạn văn bản cho [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Portion) và sau đó thêm nó vào bộ sưu tập portion của paragraph.
- Lưu bản thuyết trình dưới dạng tệp PPTX.

```java
// Tạo một đối tượng Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Tạo hộp văn bản
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Tạo đoạn văn cho văn bản siêu chỉ số
    IParagraph superPar = new Paragraph();

    // Tạo portion với văn bản thường
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Tạo portion với văn bản siêu chỉ số
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Tạo đoạn văn cho văn bản chỉ số dưới
    IParagraph paragraph2 = new Paragraph();

    // Tạo portion với văn bản thường
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Tạo portion với văn bản chỉ số dưới
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Thêm các đoạn văn vào hộp văn bản
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Liệu siêu chỉ số và chỉ số dưới có được giữ lại khi xuất ra PDF hoặc các định dạng khác không?**

Có, Aspose.Slides giữ đúng định dạng siêu chỉ số và chỉ số dưới khi xuất bản trình diễn sang PDF, PPT/PPTX, hình ảnh và các định dạng được hỗ trợ khác. Định dạng chuyên biệt này vẫn nguyên vẹn trong tất cả các tệp đầu ra.

**Có thể kết hợp siêu chỉ số và chỉ số dưới với các kiểu định dạng khác như in đậm hoặc in nghiêng không?**

Có, Aspose.Slides cho phép bạn pha trộn nhiều kiểu văn bản khác nhau trong một portion duy nhất. Bạn có thể bật in đậm, in nghiêng, gạch dưới và đồng thời áp dụng siêu chỉ số hoặc chỉ số dưới bằng cách cấu hình các thuộc tính tương ứng trong [PortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portionformat/).

**Định dạng siêu chỉ số và chỉ số dưới có hoạt động cho văn bản trong bảng, biểu đồ, hoặc SmartArt không?**

Có, Aspose.Slides hỗ trợ định dạng trong hầu hết các đối tượng, bao gồm các phần tử bảng và biểu đồ. Khi làm việc với SmartArt, bạn cần truy cập các phần tử thích hợp (chẳng hạn như [SmartArtNode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/smartartnode/)) và các container văn bản của chúng, sau đó cấu hình các thuộc tính [PortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portionformat/) theo cách tương tự.