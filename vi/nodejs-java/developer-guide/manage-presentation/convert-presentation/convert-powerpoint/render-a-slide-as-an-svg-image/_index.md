---
title: Kết xuất các slide trình chiếu dưới dạng hình ảnh SVG trong JavaScript
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
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong JavaScript và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện bằng Aspose.Slides."
---
## **Tổng quan**

SVG là một định dạng hình ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình truy cập, và xử lý hậu kỳ tự động. Aspose.Slides cho Node.js thông qua Java xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) khi SVG đã xuất cần phải gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc sử dụng tương tác.

## **Xuất một Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), chọn một slide và ghi nó vào một luồng bằng [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Ví dụ sau xuất mỗi slide trong một bài thuyết trình thành một tệp SVG riêng.

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

Tên tệp sử dụng [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) điều khiển việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) xác định liệu sự quay của khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) thành `true` khi văn bản phải được render mà không có ligature.

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

## **Kiểm soát cắt đầu dòng ở đầu mũi tên**

SVG 1.1 không có cài đặt marker inset để chỉ định nơi một đường nên dừng dưới đầu mũi tên. Mặc định, Aspose.Slides rút ngắn đường đã xuất để nét vẽ không nhô ra qua marker. Gọi [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) với `true` để vẽ nét tới cuối điểm gốc của đường. Cài đặt này chỉ ảnh hưởng đến đầu ra SVG. Đường vẫn giữ vị trí và độ dài trên slide.

Ví dụ vẽ các đầu mũi tên hình tam giác và kim cương trên các đường rộng 2 và 10 điểm. Nó xuất cùng một slide hai lần, chỉ thay đổi tùy chọn cắt.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

So sánh cho thấy đầu mũi tên tam giác trên đường 10 điểm. Khi bật cắt, đầu mũi nhọn. Khi tắt cắt, nét vẽ nhô ra qua các mặt nghiêng của marker và để lại một đầu phẳng.

![Tam giác 10 điểm phóng to với đầu nhọn khi bật cắt và đầu phẳng khi tắt cắt](line-end-cropping.png)

Trong các đường khác của ví dụ, nét nhô ra ít đáng chú ý hơn trên tam giác 2 điểm. Kim cương đã tô đầy che phần cuối của nét ở cả hai độ rộng.

## **Kiểm soát Văn bản và Phông chữ**

Khi xuất slide sang SVG, bạn có thể kiểm soát việc văn bản có giữ dưới dạng văn bản hay chuyển thành đồ họa vector, và cách phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng tính đồng nhất hình ảnh, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG đã xuất.

### **Biểu diễn toàn bộ văn bản dưới dạng vector**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh đồng nhất hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hoặc tìm kiếm được dưới dạng văn bản SVG.

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

### **Chọn cách xử lý Phông chữ Ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông trong SVG, hoặc `Vectorize` để render chỉ những văn bản dùng phông chữ ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông.

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

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) để giảm độ phân giải của hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) để bỏ qua các vùng đã cắt của nguồn, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) để kiểm soát chất lượng mã hóa JPEG. Các cài đặt này giảm kích thước tệp nhưng có thể ảnh hưởng đến độ trung thực hoặc dữ liệu hình ảnh được giữ lại.

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

## **Kiểm soát Độ phân giải Raster hóa Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) đặt giới hạn độ phân giải thấp hơn cho việc raster hoá metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một hình ảnh EMF hoặc WMF được raster hoá. Nó không xác định DPI toàn cầu cho SVG hoặc buộc mọi đối tượng trên slide trở thành hình ảnh raster.

Tải về [metafile-rasterization.pptx](metafile-rasterization.pptx), trong đó chứa một hình ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên với ba độ phân giải raster hoá khác nhau thông qua [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

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

Trong đầu ra, EMF trở thành một PNG nhúng trong mỗi SVG. Các đo lường sau dành cho bản thuyết trình được cung cấp; chúng không phải là công thức chung để chuyển DPI sang kích thước pixel.

| DPI raster hoá Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh bên dưới cho thấy cùng một khu vực raster nhúng ở cùng kích thước hiển thị phóng đại. Các đường chéo hiển thị hiện tượng pixel hoá ở DPI 72 và các cạnh mượt hơn ở độ phân giải cao hơn, trong khi kích thước tệp SVG tăng. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hoặc thay đổi mọi hình ảnh đã xuất.

![Chi tiết đường chéo phóng to ở DPI 72, 150 và 300](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) kiểm soát việc giảm độ phân giải hình ảnh và có thể che giấu ảnh hưởng của việc thay đổi độ phân giải raster hoá metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) kiểm soát chất lượng mã hóa JPEG, không phải độ phân giải raster hoá metafile.

## **Gán ID ổn định cho Hình dạng và Văn bản**

Chuyển một bộ điều khiển định dạng tới [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) để thiết lập [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) cho mỗi hình dạng SVG. Một bộ điều khiển cũng xử lý các span văn bản có thể đặt giá trị [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) trên các phần tử `tspan` của văn bản.

Bộ điều khiển sau sử dụng [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), giá trị này ổn định trong suốt vòng đời của hình dạng, và một bộ đếm lặp lại cho các span văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản thuyết trình không thay đổi.

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

Trong một bộ điều khiển định dạng, gọi [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) với giá trị [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) để thêm một trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán bộ điều khiển bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

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

Trang chủ có thể định nghĩa hàm JavaScript được tham chiếu bởi trình xử lý. Gán ID và trình xử lý sự kiện cho phép trình xem slide, cải thiện khả năng truy cập và các quy trình SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) khi chỉ những văn bản sử dụng phông chữ ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng việc nén các hình ảnh nhúng, xóa các vùng ảnh đã cắt và chọn các tệp phông chữ được liên kết khi môi trường đích có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải ảnh thấp hơn, chất lượng JPEG thấp hơn và văn bản vector hoá mỗi loại đều có sự đánh đổi về chất lượng và kích thước.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một bộ điều khiển định dạng, sau đó chọn các yếu tố SVG phù hợp trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.