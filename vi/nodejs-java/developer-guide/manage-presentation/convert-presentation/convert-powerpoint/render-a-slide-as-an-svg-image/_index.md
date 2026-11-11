---
title: "Xuất các slide trình chiếu thành hình ảnh SVG trong JavaScript"
linktitle: "Slide sang SVG"
type: docs
weight: 50
url: /vi/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint sang SVG"
- "trình chiếu sang SVG"
- "slide sang SVG"
- "PPT sang SVG"
- "PPTX sang SVG"
- "tùy chọn xuất SVG"
- "SVG tương tác"
- "PowerPoint"
- "trình chiếu"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong JavaScript và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình truy cập, và xử lý hậu kỳ tự động. Aspose.Slides cho Node.js thông qua Java xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) khi SVG được xuất cần gọn nhẹ, nhất quán trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), chọn một slide và ghi nó vào stream bằng [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Ví dụ sau xuất mỗi slide trong một bản trình bày thành một tệp SVG riêng.

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

Tên tệp sử dụng [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một shape riêng lẻ bằng [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) khi trình xem slide hoặc trang web chỉ cần shape đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) kiểm soát việc render SVG. Đối với các khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) xác định xem quay khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) thành `true` khi văn bản phải được render mà không có ligature.

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

Khi xuất slide sang SVG, bạn có thể kiểm soát việc văn bản giữ dạng văn bản hay được chuyển thành đồ họa vector, và cách các phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng tính nhất quán hình ảnh, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG đã xuất.

### **Vector hoá toàn bộ Văn bản**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh đồng nhất hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hoặc tìm kiếm dưới dạng văn bản SVG.

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

### **Chọn cách Xử lý Phông chữ Ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông chữ trong SVG, hoặc `Vectorize` để render chỉ những văn bản sử dụng phông chữ bên ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng.

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

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) để giảm độ phân giải của các hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) để bỏ qua các vùng ảnh đã cắt, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là độ trung thực hình ảnh hoặc dữ liệu ảnh được giữ lại.

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

## **Kiểm soát Độ phân giải Raster hoá Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) đặt giới hạn độ phân giải thấp nhất cho việc raster hoá metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một hình ảnh EMF hoặc WMF được raster hoá. Nó không định nghĩa DPI toàn cục cho SVG hoặc buộc mọi đối tượng trên slide trở thành hình raster.

Tải xuống [metafile-rasterization.pptx](metafile-rasterization.pptx), tệp chứa hình ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên của nó ở ba độ phân giải raster hoá khác nhau qua [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Trong đầu ra, EMF đã trở thành một PNG nhúng trong mỗi SVG. Các đo lường sau áp dụng cho bản trình bày được cung cấp; chúng không phải là công thức chung để chuyển DPI sang kích thước pixel.

| DPI raster hoá Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây hiển thị cùng một khu vực raster nhúng tại cùng kích thước hiển thị được phóng to. Các đường chéo cho thấy hiện tượng pixel hoá ở 72 DPI và các cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng kích thước. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hoặc thay đổi mọi hình ảnh đã xuất.

![Chi tiết đường chéo đã phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) kiểm soát việc giảm độ phân giải hình ảnh và có thể che giấu hiệu quả của việc thay đổi độ phân giải raster hoá metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) kiểm soát chất lượng mã hoá JPEG, không phải độ phân giải raster hoá metafile.

## **Gán ID ổn định cho Shapes và Text**

Gửi một bộ điều khiển định dạng tới [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) để đặt [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) cho mỗi shape SVG. Bộ điều khiển cũng xử lý các span văn bản có thể đặt giá trị [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) trên các phần tử `tspan` của văn bản.

Bộ điều khiển dưới đây sử dụng [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), giá trị này ổn định trong suốt vòng đời của shape, và một bộ đếm lặp lại cho các span văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình bày không thay đổi.

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

## **Thêm trình xử lý sự kiện SVG**

Trong bộ điều khiển định dạng, gọi [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) với một giá trị [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một shape đã xuất. Gán bộ điều khiển bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

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

Trang chủ có thể định nghĩa hàm JavaScript được trình xử lý tham chiếu. Gán ID và trình xử lý sự kiện cho phép trình xem slide, cải thiện truy cập, và các quy trình SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) khi mọi văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) khi chỉ những văn bản sử dụng phông chữ bên ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng cách nén các hình ảnh nhúng, xóa các vùng ảnh đã cắt, và chọn các tệp phông chữ được liên kết khi môi trường đích có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải ảnh thấp hơn, chất lượng JPEG thấp hơn và văn bản đã vector hoá đều có các cân bằng giữa chất lượng và kích thước khác nhau.

**Tôi có thể sửa đổi các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua bộ điều khiển định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.