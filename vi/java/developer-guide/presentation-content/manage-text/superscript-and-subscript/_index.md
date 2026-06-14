---
title: Quản lý Siêu chỉ và Chỉ dưới trong các bản trình bày bằng Java
linktitle: Siêu chỉ và Chỉ dưới
type: docs
weight: 80
url: /vi/java/superscript-and-subscript/
keywords:
- siêu chỉ
- chỉ dưới
- thêm siêu chỉ
- thêm chỉ dưới
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Nắm vững siêu chỉ và chỉ dưới trong Aspose.Slides cho Java và nâng cấp bản trình bày của bạn với định dạng văn bản chuyên nghiệp để đạt hiệu quả tối đa."
---
## **Tổng quan**

Aspose.Slides cung cấp các tính năng để tích hợp văn bản siêu chỉ và chỉ dưới vào các bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) của bạn. Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học, hoặc chú thích nội dung bằng chú thích dưới cùng, các tùy chọn định dạng đặc biệt này giúp duy trì sự rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng phong cách siêu chỉ và chỉ dưới một cách liền mạch và đảm bảo kết quả chuyên nghiệp cho mỗi slide.

## **Quản lý Văn bản Siêu Chỉ và Chỉ Dưới**

Bạn có thể thêm văn bản siêu chỉ và chỉ dưới vào bất kỳ phần đoạn văn nào. Để thêm văn bản Siêu Chỉ hoặc Chỉ Dưới trong khung văn bản Aspose.Slides, phải sử dụng phương thức [**setEscapement**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) của lớp [PortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/PortionFormat).

Thuộc tính này trả về hoặc đặt văn bản siêu chỉ hoặc chỉ dưới (giá trị từ -100% (chỉ dưới) đến 100% (siêu chỉ)). Ví dụ:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) loại [Rectangle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapeType#Rectangle) vào slide.
- Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrame) liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape).
- Xóa các Paragraph hiện có
- Tạo một đối tượng paragraph mới để chứa văn bản siêu chỉ và thêm nó vào [IParagraphs collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrame#getParagraphs--) của [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrame).
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion trong khoảng từ 0 đến 100 để thêm siêu chỉ. (0 có nghĩa là không có siêu chỉ)
- Đặt một số văn bản cho [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Portion) và sau đó thêm nó vào bộ sưu tập portion của paragraph.
- Tạo một đối tượng paragraph mới để chứa văn bản chỉ dưới và thêm nó vào IParagraphs collection của ITextFrame.
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion trong khoảng từ 0 đến -100 để thêm chỉ dưới. (0 có nghĩa là không có chỉ dưới)
- Đặt một số văn bản cho [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Portion) và sau đó thêm nó vào bộ sưu tập portion của paragraph.
- Lưu bản trình bày dưới dạng tệp PPTX.

Việc thực hiện các bước trên được đưa ra dưới đây.

```java
// Tạo một đối tượng lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Tạo hộp văn bản
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Tạo đoạn cho văn bản siêu chỉ
    IParagraph superPar = new Paragraph();

    // Tạo portion với văn bản thường
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Tạo portion với văn bản siêu chỉ
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Tạo đoạn cho văn bản chỉ dưới
    IParagraph paragraph2 = new Paragraph();

    // Tạo portion với văn bản thường
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Tạo portion với văn bản chỉ dưới
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Thêm các đoạn vào hộp văn bản
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Siêu chỉ và chỉ dưới có được giữ nguyên khi xuất ra PDF hoặc các định dạng khác không?**

Có, Aspose.Slides giữ đúng định dạng siêu chỉ và chỉ dưới khi xuất bản trình bày sang PDF, PPT/PPTX, hình ảnh và các định dạng hỗ trợ khác. Định dạng đặc biệt này vẫn giữ nguyên trong tất cả các tệp đầu ra.

**Siêu chỉ và chỉ dưới có thể kết hợp với các kiểu định dạng khác như in đậm hoặc in nghiêng không?**

Có, Aspose.Slides cho phép bạn kết hợp nhiều kiểu định dạng văn bản trong một portion duy nhất. Bạn có thể bật in đậm, in nghiêng, gạch chân và đồng thời áp dụng siêu chỉ hoặc chỉ dưới bằng cách cấu hình các thuộc tính tương ứng trong [PortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portionformat/).

**Định dạng siêu chỉ và chỉ dưới có hoạt động cho văn bản bên trong bảng, biểu đồ hoặc SmartArt không?**

Có, Aspose.Slides hỗ trợ định dạng trong hầu hết các đối tượng, bao gồm các phần tử bảng và biểu đồ. Khi làm việc với SmartArt, bạn cần truy cập vào các phần tử thích hợp (như [SmartArtNode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/smartartnode/)) và các container văn bản của chúng, sau đó cấu hình các thuộc tính [PortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portionformat/) theo cách tương tự.