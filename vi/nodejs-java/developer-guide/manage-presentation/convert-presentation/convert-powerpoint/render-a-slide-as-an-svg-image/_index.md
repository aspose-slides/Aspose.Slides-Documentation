---
title: Render Presentation Slides as SVG Images in JavaScript
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bản trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- các tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong JavaScript và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện bằng Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình truy cập, và xử lý hậu kỳ tự động. Aspose.Slides cho Node.js thông qua Java xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/) khi SVG được xuất cần phải gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc sử dụng tương tác.

## **Xuất một Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/), chọn một slide và ghi nó vào luồng bằng [Slide.writeAsSvg](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/writeassvg/). Ví dụ sau xuất mỗi slide trong một bản trình bày dưới dạng một tệp SVG riêng.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Tên tệp sử dụng [Slide.getSlideNumber](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/getslidenumber/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.writeAsSvg](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setuseframesize/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) xác định liệu việc quay khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) thành `true` khi văn bản phải được render mà không có ligature.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Kiểm soát Văn bản và Phông chữ**

### **Vector hoá toàn bộ Văn bản**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc vào phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hay tìm kiếm được dưới dạng văn bản SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Chọn cách xử lý Phông chữ Ngoại vi**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải ngoại vi. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để nhúng dữ liệu phông chữ vào SVG, hoặc `Vectorize` để render chỉ văn bản sử dụng phông chữ ngoại vi dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Giảm kích thước hình ảnh nhúng**

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) để giảm độ phân giải của các hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) để bỏ qua các khu vực ảnh đã cắt, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setjpegquality/) để kiểm soát chất lượng mã hóa JPEG. Các cài đặt này giảm kích thước tệp với chi phí là độ trung thực của hình ảnh hoặc dữ liệu ảnh được giữ lại.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Gán ID ổn định cho Các hình dạng và Văn bản**

Cung cấp một bộ điều khiển định dạng cho [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) để đặt [SvgShape.setId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgshape/setid/) cho mỗi hình dạng SVG. Một bộ điều khiển cũng xử lý các đoạn văn bản có thể đặt giá trị [SvgTSpan.setId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgtspan/setid/) trên các phần tử `tspan` của văn bản.

Bộ điều khiển sau sử dụng [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), giá trị này ổn định trong suốt vòng đời của hình dạng, và một bộ đếm có thể lặp lại cho các đoạn văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình bày không thay đổi.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Thêm Trình xử lý Sự kiện SVG**

Trong một bộ điều khiển định dạng, gọi [SvgShape.setEventHandler](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgshape/seteventhandler/) với một giá trị [SvgEvent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán bộ điều khiển bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

Trang chủ có thể định nghĩa hàm JavaScript được tham chiếu bởi trình xử lý. Gán ID và trình xử lý sự kiện cho phép các trình xem slide, cải thiện khả năng truy cập, và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ ngoại vi cần được chuyển đổi thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng việc nén các hình ảnh nhúng, xóa các khu vực ảnh đã cắt, và chọn các tệp phông chữ được liên kết khi môi trường đích có thể cung cấp chúng. Kiểm tra kết quả vì giảm độ phân giải ảnh, giảm chất lượng JPEG, và vector hoá văn bản mỗi yếu tố đều có sự cân bằng giữa chất lượng và kích thước khác nhau.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một bộ điều khiển định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.