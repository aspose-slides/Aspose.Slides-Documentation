---
title: Hiển thị các slide trình chiếu dưới dạng hình ảnh SVG trong JavaScript
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- lưu PPT dưới dạng SVG
- lưu PPTX dưới dạng SVG
- xuất PPT sang SVG
- xuất PPTX sang SVG
- hiển thị slide
- chuyển đổi slide
- xuất slide
- hình ảnh vector
- PowerPoint
- trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách hiển thị các slide PowerPoint dưới dạng hình ảnh SVG bằng Aspose.Slides cho Node.js qua Java. Hình ảnh chất lượng cao với các ví dụ mã JavaScript đơn giản."
---
## **Tổng quan**

Bài viết này giải thích cách hiển thị các slide trình chiếu dưới dạng hình ảnh SVG bằng Aspose.Slides. Nó mô tả định dạng SVG và các ưu điểm của nó, bao gồm khả năng mở rộng, khả năng tiếp cận và tính thích hợp cho phát triển web.

Bạn sẽ học cách tải tệp trình chiếu, duyệt qua các slide của nó và lưu mỗi slide dưới dạng một tệp SVG riêng. Bài viết đề cập đến các định dạng trình chiếu PowerPoint và OpenDocument, bao gồm PPT, PPTX, ODP và PPS, và chỉ ra cách thực hiện việc chuyển đổi một cách lập trình bằng lớp `Presentation` và phương thức `writeAsSvg`.

## **Định dạng SVG**

SVG—viết tắt của Scalable Vector Graphics—là một định dạng đồ họa tiêu chuẩn được sử dụng để hiển thị hình ảnh hai chiều. SVG lưu trữ hình ảnh dưới dạng vector trong XML với các chi tiết xác định hành vi hoặc giao diện của chúng.

SVG là một trong số ít các định dạng hình ảnh đáp ứng các tiêu chuẩn cao về: khả năng mở rộng, tính tương tác, hiệu năng, khả năng tiếp cận, khả năng lập trình và các yếu tố khác. Vì những lý do này, nó thường được sử dụng trong phát triển web.

Bạn có thể muốn sử dụng tệp SVG khi cần

- **in trình chiếu của bạn ở *định dạng rất lớn*.** Hình ảnh SVG có thể mở rộng lên bất kỳ độ phân giải hoặc mức nào. Bạn có thể thay đổi kích thước hình ảnh SVG bao nhiêu lần cũng được mà không làm giảm chất lượng.
- **sử dụng biểu đồ và đồ thị từ các slide trong *các môi trường hoặc nền tảng khác nhau*.** Hầu hết các trình đọc đều có thể giải mã tệp SVG.
- **sử dụng *kích thước nhỏ nhất có thể của hình ảnh*.** Tệp SVG thường nhỏ hơn so với các định dạng có độ phân giải cao tương đương, đặc biệt là các định dạng dựa trên bitmap (JPEG hoặc PNG).

## **Xuất Slide dưới dạng Hình ảnh SVG**

Aspose.Slides for Node.js via Java cho phép bạn xuất các slide trong trình chiếu dưới dạng hình ảnh SVG. Thực hiện các bước sau để tạo ra các hình ảnh SVG:

1. Tạo một thể hiện của lớp `Presentation`.
2. Duyệt qua tất cả các slide trong trình chiếu.
3. Ghi mỗi slide vào tệp SVG riêng thông qua `FileOutputStream`.

{{% alert color="primary" %}} 

Bạn có thể muốn thử [ứng dụng web miễn phí](https://products.aspose.app/slides/vi/conversion/ppt-to-svg) mà chúng tôi đã triển khai chức năng chuyển đổi PPT sang SVG từ Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Mã mẫu này bằng JavaScript cho thấy cách chuyển đổi PPT sang SVG bằng Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Tại sao SVG kết quả có thể hiển thị khác nhau trên các trình duyệt?**

Hỗ trợ các tính năng SVG cụ thể được triển khai khác nhau bởi các engine trình duyệt. Các tham số của [SVGOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/) giúp làm giảm sự không tương thích.

**Liệu có thể xuất không chỉ các slide mà còn các hình dạng riêng lẻ sang SVG không?**

Có. Bất kỳ [hình dạng nào cũng có thể được lưu dưới dạng SVG riêng](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/), thuận tiện cho biểu tượng, hình ảnh minh họa và việc tái sử dụng đồ họa.

**Có thể gộp nhiều slide thành một SVG duy nhất (strip/document) không?**

Kịch bản tiêu chuẩn là một slide → một SVG. Việc gộp nhiều slide vào một canvas SVG duy nhất là một bước xử lý hậu kỳ thực hiện ở mức ứng dụng.