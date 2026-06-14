---
title: Tạo Trình xem Bản thuyết trình bằng JavaScript
linktitle: Trình xem Bản thuyết trình
type: docs
weight: 50
url: /vi/nodejs-java/presentation-viewer/
keywords:
- xem bản thuyết trình
- trình xem bản thuyết trình
- tạo trình xem bản thuyết trình
- xem PPT
- xem PPTX
- xem ODP
- PowerPoint
- OpenDocument
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo một trình xem bản thuyết trình tùy chỉnh bằng JavaScript với Aspose.Slides cho Node.js. Dễ dàng hiển thị các tệp PowerPoint và OpenDocument mà không cần Microsoft PowerPoint."
---
## **Giới thiệu**

Aspose.Slides for Node.js qua Java được sử dụng để tạo các tệp thuyết trình có các slide. Các slide này có thể được xem bằng cách mở bản thuyết trình trong Microsoft PowerPoint, ví dụ. Tuy nhiên, đôi khi các nhà phát triển có thể cần xem slide dưới dạng hình ảnh trong trình xem ảnh ưa thích hoặc tạo trình xem thuyết trình của riêng mình. Trong những trường hợp như vậy, Aspose.Slides cho phép bạn xuất một slide riêng lẻ thành hình ảnh. Bài viết này mô tả cách thực hiện.

## **Tạo hình ảnh SVG từ một Slide**

Để tạo hình ảnh SVG từ một slide trong bản thuyết trình bằng Aspose.Slides, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy tham chiếu slide bằng chỉ mục của nó.
3. Mở một luồng tệp.
4. Lưu slide dưới dạng hình ảnh SVG vào luồng tệp.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Tạo SVG với ID Hình dạng tùy chỉnh**

Aspose.Slides có thể được sử dụng để tạo một [SVG](https://docs.fileformat.com/page-description-language/svg/) từ một slide với ID hình dạng tùy chỉnh. Để thực hiện điều này, hãy sử dụng phương thức `setId` từ [SvgShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` có thể được dùng để đặt ID cho hình dạng.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Tạo hình ảnh thu nhỏ cho Slide**

Aspose.Slides giúp bạn tạo các hình ảnh thu nhỏ của slide. Để tạo một hình thu nhỏ của slide bằng Aspose.Slides, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy tham chiếu slide bằng chỉ mục của nó.
3. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với tỷ lệ đã xác định.
4. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng hình ảnh mong muốn nào.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Tạo hình ảnh thu nhỏ cho Slide với Kích thước do Người dùng Định nghĩa**

Để tạo hình ảnh thu nhỏ cho slide với kích thước do người dùng định nghĩa, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy tham chiếu slide bằng chỉ mục của nó.
3. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với kích thước đã định nghĩa.
4. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng hình ảnh mong muốn nào.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Tạo hình ảnh thu nhỏ cho Slide với Ghi chú Diễn giả**

Để tạo hình thu nhỏ của slide có ghi chú diễn giả bằng Aspose.Slides, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [RenderingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/).
2. Sử dụng phương thức `RenderingOptions.setSlidesLayoutOptions` để đặt vị trí của ghi chú diễn giả.
3. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
4. Lấy tham chiếu slide bằng chỉ mục của nó.
5. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với các tùy chọn render.
6. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng hình ảnh mong muốn nào.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Ví dụ Trực tiếp**

Bạn có thể thử ứng dụng miễn phí [**Aspose.Slides Viewer**](https://products.aspose.app/slides/vi/viewer/) để xem những gì bạn có thể triển khai với API Aspose.Slides:

![Trình xem PowerPoint trực tuyến](online-PowerPoint-viewer.png)

## **Câu hỏi thường gặp**

**Tôi có thể nhúng trình xem bản thuyết trình vào một ứng dụng web Node.js không?**

Có. Bạn có thể sử dụng Aspose.Slides ở phía máy chủ để render các slide dưới dạng hình ảnh hoặc HTML và hiển thị chúng trong trình duyệt. Các tính năng điều hướng và phóng to/thu nhỏ có thể được triển khai bằng JavaScript để tạo trải nghiệm tương tác.

**Cách tốt nhất để hiển thị slide trong một trình xem tùy chỉnh là gì?**

Phương pháp được khuyến nghị là render mỗi slide dưới dạng hình ảnh (ví dụ: PNG hoặc SVG) hoặc chuyển đổi nó sang HTML bằng Aspose.Slides, sau đó hiển thị kết quả trong một picture box (đối với desktop) hoặc trong một container HTML (đối với web).

**Làm sao để tôi xử lý các bản thuyết trình lớn với nhiều slide?**

Đối với các bộ slide lớn, hãy xem xét việc tải lười (lazy-loading) hoặc render slide khi cần (on-demand). Điều này có nghĩa là chỉ tạo nội dung của một slide khi người dùng điều hướng tới, giảm bộ nhớ và thời gian tải.