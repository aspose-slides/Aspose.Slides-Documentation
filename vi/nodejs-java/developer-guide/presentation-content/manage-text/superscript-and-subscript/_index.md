---
title: Quản lý Siêu Chỉ Số và Chỉ Số Dưới trong Bài Thuyết Trình Sử dụng JavaScript
linktitle: Siêu Chỉ Số và Chỉ Số Dưới
type: docs
weight: 80
url: /vi/nodejs-java/superscript-and-subscript/
keywords:
- siêu chỉ số
- chỉ số dưới
- thêm siêu chỉ số
- thêm chỉ số dưới
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Làm chủ siêu chỉ số và chỉ số dưới trong Aspose.Slides cho Node.js thông qua Java và nâng cao bài thuyết trình của bạn với định dạng văn bản chuyên nghiệp để đạt tối đa tác động."
---
## **Tổng quan**

Aspose.Slides cung cấp các tính năng để tích hợp văn bản siêu chỉ số và chỉ số dưới vào các bài thuyết trình PowerPoint (PPT, PPTX) và OpenDocument (ODP) của bạn. Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học, hoặc chú thích nội dung bằng chú thích chân trang, các tùy chọn định dạng chuyên biệt này giúp duy trì sự rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng các kiểu siêu chỉ số và chỉ số dưới một cách liền mạch và đảm bảo kết quả chuyên nghiệp cho từng slide.

## **Quản lý Văn bản Siêu Chỉ Số và Chỉ Số Dưới**

Bạn có thể thêm văn bản siêu chỉ số và chỉ số dưới vào bất kỳ phần đoạn văn nào. Để thêm văn bản Siêu Chỉ Số hoặc Chỉ Số Dưới trong khung văn bản Aspose.Slides, bạn phải sử dụng phương thức [**setEscapement**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) của lớp [PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PortionFormat) .

Thuộc tính này trả về hoặc đặt văn bản siêu chỉ số hoặc chỉ số dưới (giá trị từ -100% (chỉ số dưới) đến 100% (siêu chỉ số)). Ví dụ:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) dạng [Rectangle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeType#Rectangle) vào slide.
- Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame) liên kết với [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) .
- Xóa các Paragraphs hiện có
- Tạo một đối tượng paragraph mới để chứa văn bản siêu chỉ số và thêm nó vào [Paragraphs collection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame#getParagraphs--) của [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame) .
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion trong khoảng từ 0 đến 100 để thêm siêu chỉ số. (0 có nghĩa là không có siêu chỉ số)
- Đặt một số văn bản cho [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Portion) và sau đó thêm nó vào collection của portion trong paragraph.
- Tạo một đối tượng paragraph mới để chứa văn bản chỉ số dưới và thêm nó vào IParagraphs collection của ITextFrame.
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion trong khoảng từ 0 đến -100 để thêm chỉ số dưới. (0 có nghĩa là không có chỉ số dưới)
- Đặt một số văn bản cho [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Portion) và sau đó thêm nó vào collection của portion trong paragraph.
- Lưu bản trình bày dưới dạng tệp PPTX.

Việc thực hiện các bước trên được đưa ra dưới đây.

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide
    var slide = pres.getSlides().get_Item(0);
    // Tạo hộp văn bản
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Tạo đoạn văn cho văn bản siêu chỉ số
    var superPar = new aspose.slides.Paragraph();
    // Tạo phần văn bản với nội dung thường
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Tạo phần văn bản với siêu chỉ số
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Tạo đoạn văn cho văn bản chỉ số dưới
    var paragraph2 = new aspose.slides.Paragraph();
    // Tạo phần văn bản với nội dung thường
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Tạo phần văn bản với chỉ số dưới
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Thêm các đoạn văn vào hộp văn bản
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Liệu siêu chỉ số và chỉ số dưới có được giữ nguyên khi xuất ra PDF hoặc các định dạng khác không?**

Có, Aspose.Slides giữ đúng định dạng siêu chỉ số và chỉ số dưới khi xuất bản trình chiếu sang PDF, PPT/PPTX, hình ảnh và các định dạng hỗ trợ khác. Định dạng chuyên biệt này vẫn nguyên vẹn trong tất cả các tệp đầu ra.

**Siêu chỉ số và chỉ số dưới có thể được kết hợp với các kiểu định dạng khác như in đậm hoặc in nghiêng không?**

Có, Aspose.Slides cho phép bạn kết hợp nhiều kiểu chữ trong một portion duy nhất. Bạn có thể bật in đậm, in nghiêng, gạch chân và đồng thời áp dụng siêu chỉ số hoặc chỉ số dưới bằng cách cấu hình các thuộc tính tương ứng trong [PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/) .

**Định dạng siêu chỉ số và chỉ số dưới có hoạt động cho văn bản bên trong bảng, biểu đồ hoặc SmartArt không?**

Có, Aspose.Slides hỗ trợ định dạng trong hầu hết các đối tượng, bao gồm các phần tử bảng và biểu đồ. Khi làm việc với SmartArt, bạn cần truy cập các phần tử phù hợp (như [SmartArtNode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartnode/)) và các container văn bản của chúng, sau đó cấu hình các thuộc tính [PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/) theo cách tương tự.